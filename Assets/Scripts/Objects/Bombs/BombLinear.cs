using UnityEngine;

public class BombLinear : BombBehavior {

    GameObject player;

    public void setPlayer (GameObject value) {
        player = value;
    }
    public override void Explode (Vector2 position) {
        //Vector3Int playerDirection = player.GetDirection();
        this.maxLength = Constants.BOMB_LINEAR_LEN;

        // ExplodeCell(originCell, 0);
        for (int i = 1; i < this.maxLength; i++) {
            // ExplodeCell(originCell + playerDirection, i);
        }
    }

}