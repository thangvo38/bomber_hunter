using UnityEngine;

public class BombBlast : BombBehavior {
    public GameObject specialExplosionPrefab;
    public override void Explode (Vector2 position) {
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
        GameObject explosion = (GameObject) Instantiate (specialExplosionPrefab, pos, Quaternion.identity, this.transform);
        if (currentLength == 0) {
            return false;
        } else {
            return ExplodeCell (Services.ToVectorOne (direction) * (currentLength + 1), currentLength + 1);
        }
    }

}