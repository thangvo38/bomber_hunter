using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour {
	public Tilemap groundTiles;
	public Tilemap blockTiles;
	public Tilemap objectTiles;

	public bool isInvisible = false;
	public int lives = 3;

	public bool isMoving = false;

  public float moveSpeed = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving)
		{
			return;
		}

    int horizontal = 0;
    int vertical = 0;
    horizontal = (int)(Input.GetAxisRaw("Horizontal"));
    vertical = (int)(Input.GetAxisRaw("Vertical"));

    if ( horizontal != 0 )
        vertical = 0;
  
    if (horizontal != 0 || vertical != 0)
    {
        Move(horizontal, vertical);
    }
	}

  void Move(int x, int y)
  {
    Vector2 currentCell = transform.position;
    Vector2 targetCell = currentCell + new Vector2(x, y);

    bool isOnGround = getCell(groundTiles, currentCell) != null;
    bool hasGround = getCell(groundTiles, targetCell) != null;
    bool hasBlock = getCell(blockTiles, targetCell) != null || getCell(objectTiles, targetCell) != null;

    if (isOnGround)
    {
      if (hasGround && !hasBlock)
      {
        StartCoroutine(Moving(targetCell));
      }
    }
  }

  IEnumerator Moving(Vector3 destination)
  {
    isMoving = true;

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

  TileBase getCell(Tilemap tilemap, Vector2 pos)
  {
    return tilemap == null ? null : tilemap.GetTile(tilemap.WorldToCell(pos));
  }
}
