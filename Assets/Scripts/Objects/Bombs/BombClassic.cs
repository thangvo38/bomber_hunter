using System.Collections;
using UnityEngine;

public class BombClassic : BombBehavior {
    public int length = 0;

    protected override void Awake () {
        base.Awake ();
        player = GameObject.Find ("Player");
    }
    public override void Explode (Vector2 position) {
        if (length > 0) {
            maxLength = length;
        }
        ExplodeCell (Vector3Int.zero, 0);
        ExplodeCell (new Vector3Int (1, 0, 0));
        ExplodeCell (new Vector3Int (0, 1, 0));
        ExplodeCell (new Vector3Int (-1, 0, 0));
        ExplodeCell (new Vector3Int (0, -1, 0));
    
                StartCoroutine(Wait());
 
    }

        IEnumerator Wait () {
        yield return new WaitForSeconds (0.75f);
        if (player.GetComponent<Player> ().bombPlaced > 0) {
            player.GetComponent<Player> ().bombPlaced--;
        }
    }
}