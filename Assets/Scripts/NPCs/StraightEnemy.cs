using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StraightEnemy : UnitStatus {
    public int stopChance = 0;
    protected override void Awake () {
        base.Awake ();
        checkAhead = transform.Find ("CheckCollide").gameObject;
    }
    protected override void Start () {
        base.Start ();
    }

    protected override void Update () {
        base.Update ();

        if (Statics.isPause)
            return;
            
        if (lives <= 0) {
            //Add animation here
            Destroy (this.gameObject);
        }

        if (isMoving || Random.Range (0, stopChance) > 0) {
            return;
        }
        MovementControl ();
    }

    protected override void MovementControl () {
        xDir = direction.x;
        yDir = direction.y;

        if (xDir != 0)
            yDir = 0;

        if (xDir != 0 || yDir != 0) {
            direction = new Vector2Int (xDir, yDir);
            Move (xDir, yDir);

            if (!isMoving) {
                direction *= -1;
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