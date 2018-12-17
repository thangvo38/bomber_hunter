using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SemiFinalBoss : UnitStatus {

    GameObject player = null;
    bool findOtherWay = false;

    protected override void Awake () {
        base.Awake ();
        player = GameObject.Find ("Player");
        blockTiles = new List<Tilemap>();
    }

    protected override void Update () {
        base.Update ();

        if (lives <= 0) {
            //Add animation here
        }

        if (isMoving) {
            return;
        }

        isMoving = true;
        MovementControl ();
    }

    protected override void MovementControl () {

        Vector3Int newDir;
        if (!findOtherWay)
            newDir = Services.ToVectorOne ((Vector3Int.FloorToInt (player.transform.position - this.transform.position)));
        else {
            newDir = new Vector3Int(Random.Range(-1, 2),Random.Range(-1, 2), 0);
            findOtherWay = false;
        }
        xDir = newDir.x;
        yDir = newDir.y;

        if (xDir != 0)
            yDir = 0;

        if (xDir != 0 || yDir != 0) {
            direction = new Vector2Int (xDir, yDir);
            Move (xDir, yDir);
        }
    }

    protected override void OnCollisionEnter2D (Collision2D other) {
        Services.IgnoreCollisionByTag (this.gameObject, other, Constants.ENEMY_TAG);
        Services.IgnoreCollisionByTag (this.gameObject, other, Constants.DESTRUTABLE_TAG);
        Services.IgnoreCollisionByTag (this.gameObject, other, Constants.BOMB_TAG);
        Services.IgnoreCollisionByTag (this.checkAhead, other, Constants.BOMB_TAG);

        switch (other.gameObject.tag) {
            case Constants.ENEMY_WALL:
                stopMoving ();
                isMoving = false;
                // direction *= -1;
                Move (direction.x, direction.y);
                findOtherWay = true;
                break;
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
            isInvisible = true;
            base.Damage ();
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