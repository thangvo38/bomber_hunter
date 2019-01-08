using UnityEngine;

public class BombBlast : BombBehavior {

    GameObject player;

    protected override void Awake () {
        base.Awake ();
        player = GameObject.Find ("Player");
    }

    public override void Explode (Vector2 position) {
        if (player.GetComponent<Player> ().bombPlaced > 0) {
            player.GetComponent<Player> ().bombPlaced--;
        }

        this.maxLength = Constants.BOMB_BLAST_LEN;
        ExplodeCell (Vector3Int.zero, 0);
        ExplodeCell (new Vector3Int (1, 0, 0));
        ExplodeCell (new Vector3Int (1, 1, 0));
        ExplodeCell (new Vector3Int (0, 1, 0));
        ExplodeCell (new Vector3Int (-1, 1, 0));
        ExplodeCell (new Vector3Int (-1, 0, 0));
        ExplodeCell (new Vector3Int (-1, -1, 0));
        ExplodeCell (new Vector3Int (0, -1, 0));
        ExplodeCell (new Vector3Int (1, -1, 0));
    }

    protected override bool ExplodeCell (Vector3Int direction, int currentLength = 1) {
        if (currentLength >= this.maxLength) {
            return false;
        }

        Vector3 pos = this.transform.position + direction;
        GameObject explosion = (GameObject) Instantiate (explosionPrefab, pos, Quaternion.identity, this.transform);
        if (currentLength == 0) {
            return false;
        } else {
            return ExplodeCell (Services.ToVectorOne (direction) * (currentLength + 1), currentLength + 1);
        }
    }

}