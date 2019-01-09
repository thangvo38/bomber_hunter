using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombEnemy : UnitStatus {
    public int stopChance = 0;

    public GameObject bombPrefab;
    List<Vector2Int> availableDirections;
    int previousDir;
    int failAttempt = 0;

    protected override void Awake () {
        base.Awake ();
        checkAhead = transform.Find ("CheckCollide").gameObject;

        availableDirections = new List<Vector2Int> {
            new Vector2Int (1, 0),
            new Vector2Int (-1, 0),
            new Vector2Int (0, 1),
            new Vector2Int (0, -1),
        };

        previousDir = availableDirections.IndexOf (direction * -1);
    }
    protected override void Start () {
        base.Start ();
    }

    protected override void Update () {
        base.Update ();

        if (lives <= 0) {
            //Add animation here
            Destroy (this.gameObject);
        }

        if (isMoving || Random.Range (0, stopChance) > 0) {
            AttackControl ();
            return;
        }
        isMoving = true;
        MovementControl ();
    }

    protected override void AttackControl () {
        int triggered = Random.Range (0, 100);

        if (triggered >= 99) {
            bool isOnGround = base.isOnGround (this.transform.position);
            if (isOnGround) {
                Vector3Int bombCell = groundTiles.WorldToCell (transform.position);
                GameObject bomb = Instantiate (bombPrefab, groundTiles.GetCellCenterWorld (bombCell), Quaternion.identity);
                bomb.GetComponent<BombBehavior> ().SetLength (3);
            }
        }

    }

    protected override void MovementControl () {
        // direction = new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));
        xDir = direction.x;
        yDir = direction.y;

        if (xDir != 0)
            yDir = 0;

        if (xDir != 0 || yDir != 0) {
            direction = new Vector2Int (xDir, yDir);
            Move (xDir, yDir);

            //If can't move 
            if (!isMoving) {
                failAttempt++;
                // Debug.Log ("FailAttempt:" + failAttempt);

                if (failAttempt > 3) {
                    direction = availableDirections[previousDir];
                    previousDir = availableDirections.IndexOf (direction * -1);
                    // Debug.Log ("Fail 3 times: " + direction);
                } else {
                    // Debug.Log(previousDir);
                    int newDir = Services.RandomExcept (0, 4, previousDir);
                    direction = availableDirections[newDir];
                    // Debug.Log("Fail " + failAttempt + " times: " + direction + " Previous: " + previousDir);
                }
            } else {
                failAttempt = 0;
                // Debug.Log ("FailAttempt:" + failAttempt);
                previousDir = availableDirections.IndexOf (direction * -1);
                // Debug.Log("Previos: " + availableDirections[previousDir]);
            }
        }
    }

    protected override void OnCollisionEnter2D (Collision2D other) {
        Services.IgnoreCollisionByTag (this.gameObject, other, Constants.ENEMY_TAG);

        switch (other.gameObject.tag) {
            case Constants.BOMB_TAG:
            case Constants.ENEMY_WALL:
                stopMoving ();
                isMoving = false;
                direction *= -1;
                Move (direction.x, direction.y);
                break;
        }
    }

}