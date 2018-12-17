using UnityEngine;

public class BombClassic : BombBehavior {

    public int length = 0;
    public override void Explode (Vector2 position) {
        if (length > 0)
        {
            maxLength = length;
        }
        ExplodeCell (Vector3Int.zero, 0);
        ExplodeCell (new Vector3Int (1, 0, 0));
        ExplodeCell (new Vector3Int (0, 1, 0));
        ExplodeCell (new Vector3Int (-1, 0, 0));
        ExplodeCell (new Vector3Int (0, -1, 0));
    }
}