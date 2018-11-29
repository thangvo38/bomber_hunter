using UnityEngine;

public class BombClassic : BombBehavior {
    public int fireLength = 3;
    public override void Explode (Vector2 position) {
        this.maxLength = fireLength;
        ExplodeCell (Vector3Int.zero, 0);
        ExplodeCell (new Vector3Int (1, 0, 0));
        ExplodeCell (new Vector3Int (0, 1, 0));
        ExplodeCell (new Vector3Int (-1, 0, 0));
        ExplodeCell (new Vector3Int (0, -1, 0));
    }

}