using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SemiFinalBoss : UnitStatus {

    public Vector3 startPos = new Vector3 (0.5f, 3.5f, 0f);
    GameObject player = null;
    private Rigidbody2D rb2D;
    bool returnToStart = false;
    public Vector3 targetPos;

    protected override void Awake () {
        base.Awake ();
        player = GameObject.Find ("Player");
        blockTiles = new List<Tilemap> ();
        rb2D = gameObject.AddComponent<Rigidbody2D> ();
        targetPos = player.transform.position;
    }

    protected override void Update () {
        if (lives <= 0) {
            //Add animation here
        }

        if (returnToStart && this.transform.position == startPos) {
            returnToStart = false;
        }

        if (!returnToStart && this.transform.position == player.transform.position) {
            returnToStart = true;
        }

        if (!isMoving) {
            isMoving = true;
            MovementControl ();
        }
    }

    protected override void MovementControl () {
        if (returnToStart) {
            targetPos = startPos;
        } else {
            targetPos = player.transform.position;
        }
        transform.position = Vector3.MoveTowards (transform.position, targetPos, moveSpeed * Time.deltaTime);
        isMoving = false;
    }

    protected override void OnCollisionEnter2D (Collision2D other) {
        Services.IgnoreCollisionByTag (gameObject, other, Constants.WALL_TAG);
        Services.IgnoreCollisionByTag (this.gameObject, other, Constants.ENEMY_TAG);
        Services.IgnoreCollisionByTag (this.gameObject, other, Constants.DESTRUTABLE_TAG);
        Services.IgnoreCollisionByTag (this.gameObject, other, Constants.BOMB_TAG);
        Services.IgnoreCollisionByTag (this.checkAhead, other, Constants.BOMB_TAG);

        if (other.gameObject.tag == Constants.ENEMY_WALL) {
            returnToStart = true;
        }
    }

    protected override bool containCellInList (Vector2 pos) {
        for (int i = 0; i < blockTiles.Count; i++) {
            if (blockTiles[i].gameObject.tag != Constants.DESTRUTABLE_TAG) {
                if (getCell (blockTiles[i], pos) != null || Services.GetObjectInCell (blockTiles[i], pos) != null) {
                    return true;
                }
            }
        }
        return false;
    }

    public override void Damage () {
        if (!isInvisible) {
            base.Damage ();
            isInvisible = true;
            StartCoroutine (Flash ());
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

        if (lives <= 0) {
            Destroy (this.gameObject);
        }
    }
}