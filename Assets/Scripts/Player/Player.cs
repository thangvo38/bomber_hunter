using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Player : UnitStatus {
    public int bombLimit = 3;
    public int bombPlaced = 0;
    public int bombLength = 3;
    public List<GameObject> bombs = new List<GameObject> ();
    [Range (0, 2)]
    public int curerntBombId = 1;
    protected override void Awake () {
        base.Awake ();
        checkAhead = transform.Find ("CheckCollide").gameObject;
    }
    protected override void Start () {
        base.Start ();
    }
    protected override void Update () {
        base.Update ();
        if (!Statics.isPause) {
            
            if (lives <= 0)
            {
                var data = SaveSystem.LoadGame(Statics.currentFile);
                SceneManager.LoadSceneAsync(data.stageName);
            }

            SwitchBombControl ();
            AttackControl ();
            if (isMoving) {
                return;
            }
            MovementControl ();
        }
    }
    protected override void MovementControl () {
        xDir = (int) (Input.GetAxisRaw ("Horizontal"));
        yDir = (int) (Input.GetAxisRaw ("Vertical"));

        if (xDir != 0)
            yDir = 0;

        if (xDir != 0 || yDir != 0) {
            anim.SetInteger ("dir", 1);
            direction = new Vector2Int (xDir, yDir);
            Move (xDir, yDir);
        } else {
            anim.SetInteger ("dir", 0);
        }
    }

    protected override void AttackControl () {
        bool attackButtonDown = Input.GetButtonDown ("A");
        if (canAttack && attackButtonDown) {
            bool isOnGround = base.isOnGround (this.transform.position);
            if (bombPlaced < bombLimit && isOnGround && curerntBombId <= bombs.Count && bombs[curerntBombId] != null) {
                Vector3Int bombCell = groundTiles.WorldToCell (transform.position);
                GameObject bomb = Instantiate (bombs[curerntBombId], groundTiles.GetCellCenterWorld (bombCell), Quaternion.identity);
                bomb.GetComponent<BombBehavior> ().SetLength (bombLength);
                bombPlaced++;
            }
        }
    }

    void SwitchBombControl () {
        bool switchButtonDown = Input.GetButtonDown ("B");
        if (switchButtonDown) {
            curerntBombId = curerntBombId == 2 ? 0 : curerntBombId + 1;
        }
    }

    protected override void OnCollisionEnter2D (Collision2D other) {
        base.OnCollisionEnter2D (other);
        switch (other.gameObject.tag) {
            case Constants.ENEMY_TAG:
                Damage ();
                break;
        }
    }

}