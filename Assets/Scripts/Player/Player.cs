using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : UnitStatus {
  
  public List<GameObject> bombs = new List<GameObject>();
  public int curerntBombId = 0;
  Coroutine moveCoroutine;

  // Use this for initialization
	void Start () {
    lives = 3;
    checkAhead = transform.Find("CheckCollide").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
    AttackControl();
		if (isMoving)
		{
			return;
		}
    MovementControl();
	}

  protected override void MovementControl()
  {
    xDir = (int)(Input.GetAxisRaw("Horizontal"));
    yDir = (int)(Input.GetAxisRaw("Vertical"));

    if ( xDir != 0 )
        yDir = 0;
  
    if (xDir != 0 || yDir != 0)
    {
        direction = new Vector2Int(xDir, yDir);
        Move(xDir, yDir);
    }
  }

  protected override void AttackControl()
  {
    bool attackButtonDown = Input.GetButtonDown("A");
    if (canAttack && attackButtonDown)
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
    Vector2 currentCell = transform.position;
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
    isMoving = false;
  }
  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Bomb")
    {
      if(!other.gameObject.GetComponent<Collider2D>().isTrigger)
      {
        StopCoroutine(moveCoroutine);
        isMoving = false;
        Move(0, 0);
      }
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
