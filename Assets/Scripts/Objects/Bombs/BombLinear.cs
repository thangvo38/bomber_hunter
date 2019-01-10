using UnityEngine;

public class BombLinear : BombBehavior {
    Vector3Int playerDirection;
    protected override void Awake () {
        player = GameObject.Find ("Player");
        playerDirection = new Vector3Int (player.GetComponent<UnitStatus> ().direction.x,
            player.GetComponent<UnitStatus> ().direction.y,
            0);
    }
    public void setPlayer (GameObject value) {
        player = value;
    }

    public override void Explode (Vector2 position) {
        this.maxLength = Constants.BOMB_LINEAR_LEN;

        ExplodeCell (Vector3Int.zero, 0);
        ExplodeCell (playerDirection);
    
        if (player.GetComponent<Player> ().bombPlaced > 0) {
            player.GetComponent<Player> ().bombPlaced--;
        }
    }

}