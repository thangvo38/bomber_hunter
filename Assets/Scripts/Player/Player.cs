using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour {
	public Tilemap groundTiles;
	public Tilemap blockTiles;
	public Tilemap objectTiles;
  public Tilemap bombTiles;

	public bool isInvisible = false;
	public int lives = 3;

	public bool isMoving = false;

  public float moveSpeed = 2f;
	
  public List<GameObject> bombs = new List<GameObject>();
  public int curerntBombId = 0;

  Vector3 curPos;
  Coroutine moveCoroutine;

  int xDir = 0, yDir = 1;

  GameObject checkAhead;

  // Use this for initialization
	void Start () {
		curPos = transform.position;
    checkAhead = transform.Find("CheckCollide").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
		{
			return;
		}
    MovementControl();
    AttackControl();
	}

  void MovementControl()
  {
    // int horizontal = 0;
    // int vertical = 0;
    xDir = (int)(Input.GetAxisRaw("Horizontal"));
    yDir = (int)(Input.GetAxisRaw("Vertical"));

    if ( xDir != 0 )
        yDir = 0;
  
    if (xDir != 0 || yDir != 0)
    {
        Move(xDir, yDir);
    }
  }

  void AttackControl()
  {
    bool attackButtonDown = Input.GetButtonDown("A");
    if (attackButtonDown)
    {
      bool isOnGround = getCell(groundTiles, transform.position) != null;
      if (isOnGround && curerntBombId <= bombs.Count && bombs[curerntBombId] != null)
      {
        Vector3Int bombCell = groundTiles.WorldToCell(transform.position);
        Instantiate(bombs[curerntBombId], groundTiles.GetCellCenterWorld(bombCell), Quaternion.identity);
      }
    }
  }

  void Move(int x, int y)
  {
    checkAhead.GetComponent<BoxCollider2D>().offset = new Vector2(x, y);
    Vector2 currentCell = curPos;
    Vector2 targetCell = currentCell + new Vector2(x, y);

    bool isOnGround = getCell(groundTiles, currentCell) != null;
    bool hasGround = getCell(groundTiles, targetCell) != null;
    bool hasBlock = getCell(blockTiles, targetCell) != null || getCell(objectTiles, targetCell) != null || isBlockAhead(x, y);
    if (isOnGround)
    {
      if (hasGround && !hasBlock)
      {
        isMoving = true;
        moveCoroutine = StartCoroutine(Moving(targetCell));
      }
    }
  }
  IEnumerator Moving(Vector3 destination)
  {
    float distance = (transform.position - destination).sqrMagnitude;

    while (distance > 0f)
    {
      Vector3 newPos = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * moveSpeed);
      transform.position = newPos;
      distance = (transform.position - destination).sqrMagnitude;

      yield return null;
    }
    curPos = transform.position;
    Debug.Log("Exit");
    isMoving = false;
  }
  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Bomb")
    {
      StopCoroutine(moveCoroutine);
      isMoving = false;
      Move(0, 0);
    }
  }

  TileBase getCell(Tilemap tilemap, Vector2 pos)
  {
    return tilemap == null ? null : tilemap.GetTile(tilemap.WorldToCell(pos));
  }

  bool isBlockAhead(int x, int y)
  {
    return checkAhead.GetComponent<PlayerCheckCollide>().isCollided;
  }
}
