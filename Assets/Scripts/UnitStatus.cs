using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitStatus : MonoBehaviour {
    public int lives = 1;
    public bool isInvisible = false;

    public int xDir = 0;
    
    public int yDir = 1;

    public Vector2Int direction = new Vector2Int(0, -1);

    public bool isMoving = false;

    public float moveSpeed = 2f;

    public bool canAttack = true;

    //Control Tiles
    public Tilemap groundTiles;
	public Tilemap blockTiles;
	public Tilemap objectTiles;

    protected virtual void MovementControl() {}

    protected virtual void AttackControl() {}

}