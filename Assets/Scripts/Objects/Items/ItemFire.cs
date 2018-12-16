using UnityEngine;

public class ItemFire : ItemBase {
    protected override void GainEffect (Transform target) {
        int len = target.GetComponent<Player> ().bombLength;
        len = len >= Constants.BOMB_MAX_LEN ? len : len + 1;
        target.GetComponent<Player> ().bombLength = len;
        Destroy (this.gameObject);
    }

}