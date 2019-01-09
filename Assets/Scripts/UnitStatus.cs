using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnitStatus : MonoBehaviour {
    protected Tilemap groundTiles;
    protected List<Tilemap> blockTiles;
    protected Coroutine moveCoroutine;
    protected GameObject checkAhead;
    public int lives = 1;
    public bool isInvisible = false;
    public int xDir = 0;
    public int yDir = 1;
    public Vector2Int direction = new Vector2Int (0, -1);
    public bool isMoving = false;
    public float moveSpeed = 2f;
    public bool canAttack = true;
    Vector3 correctPos;
    protected Animator anim;

    //Monobehavior functions
    protected virtual void Awake () {
        anim = GetComponent<Animator> ();
        groundTiles = transform.parent.GetComponent<NpcControl> () == null ? null : transform.parent.GetComponent<NpcControl> ().groundTiles;
        blockTiles = transform.parent.GetComponent<NpcControl> () == null ? null : transform.parent.GetComponent<NpcControl> ().blockTiles;
        correctPos = this.transform.position;
        checkAhead = transform.Find ("CheckCollide").gameObject;
    }

    protected virtual void Start () { }

    protected virtual void Update () {
        if (Statics.isPause)
            return;

        anim.SetFloat ("Y", direction.y);
        anim.SetFloat ("X", direction.x);
        anim.SetBool ("isMoving", isMoving);
        FixPosition ();
    }

    protected virtual void FixedUpdate () {

    }
    protected virtual void OnCollisionEnter2D (Collision2D other) {
        switch (other.gameObject.tag) {
            case Constants.BOMB_TAG:
                stopMoving ();
                isMoving = false;
                Move (0, 0);
                break;
        }
    }

    //Control Tiles
    protected virtual void MovementControl () { }

    protected virtual void AttackControl () { }

    public virtual void Damage () {
        if (!isInvisible)
            lives = lives <= 0 ? 0 : lives - 1;
        isInvisible = true;
        StartCoroutine (Flash ());
    }

    protected void Move (int x, int y) {
        checkAhead.GetComponent<BoxCollider2D> ().offset = new Vector2 (x, y);
        Vector2 currentCell = transform.position;
        Vector2 targetCell = currentCell + new Vector2 (x, y);

        bool isOnGround = getCell (groundTiles, currentCell) != null;
        bool hasGround = getCell (groundTiles, targetCell) != null;
        bool hasBlock = containCellInList (targetCell) || isBlockAhead (x, y);

        if (isOnGround) {
            if (hasGround && !hasBlock) {
                isMoving = true;
                moveCoroutine = StartCoroutine (Moving (targetCell));
            } else {
                isMoving = false;
                stopMoving ();
            }
        }
    }
    protected IEnumerator Moving (Vector3 destination) {
        float distance = (transform.position - destination).sqrMagnitude;
        while (distance > 0f) {
            Vector3 newPos = Vector3.MoveTowards (transform.position, destination, Time.deltaTime * moveSpeed);
            transform.position = newPos;
            distance = (transform.position - destination).sqrMagnitude;
            yield return null;
        }
        correctPos = destination;
        isMoving = false;
    }
    protected void FixPosition () {
        if (!isMoving) {
            if (this.transform.position != correctPos) {
                this.transform.position = correctPos;
            }
        }
    }
    protected TileBase getCell (Tilemap tilemap, Vector2 pos) {
        return tilemap == null ? null : tilemap.GetTile (tilemap.WorldToCell (pos));
    }

    protected bool isOnGround (Vector2 pos) {
        return getCell (groundTiles, pos) != null;
    }
    protected virtual bool containCellInList (Vector2 pos) {
        for (int i = 0; i < blockTiles.Count; i++) {
            if (getCell (blockTiles[i], pos) != null || Services.GetObjectInCell (blockTiles[i], pos) != null) {
                return true;
            }
        }
        return false;
    }
    protected bool isBlockAhead (int x, int y) {
        return checkAhead.GetComponent<PlayerCheckCollide> ().isCollided;
    }

    protected void stopMoving () {
        if (moveCoroutine != null) {
            StopCoroutine (moveCoroutine);
        }
    }

    IEnumerator Flash () {
        for (int i = 0; i < 5; i++) {
            GetComponent<SpriteRenderer> ().material.color = Color.clear;
            yield return new WaitForSeconds (0.05f);
            GetComponent<SpriteRenderer> ().material.color = Color.white;
            yield return new WaitForSeconds (0.05f);
        }
        isInvisible = false;
    }

}