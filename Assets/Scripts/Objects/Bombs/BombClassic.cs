using UnityEngine;

public class BombClassic : BombBehavior {
    public override void Explode (Vector2 position) {
        ExplodeCell (Vector3Int.zero, 0);
        ExplodeCell (new Vector3Int (1, 0, 0));
        ExplodeCell (new Vector3Int (0, 1, 0));
        ExplodeCell (new Vector3Int (-1, 0, 0));
        ExplodeCell (new Vector3Int (0, -1, 0));
    }

}