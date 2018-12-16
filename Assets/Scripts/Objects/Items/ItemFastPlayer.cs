 using UnityEngine;

public class ItemFastPlayer : ItemBase {

    float baseSpeed = 6f;
    float effectCount = 0;

    bool isTriggered = false;

    Transform player;
    protected override void Update () {
        base.Update ();

        if (isTriggered)
        {
            if (effectCount >= 5f)
            {
                if (player != null)
                {
                    player.GetComponent<Player>().moveSpeed = baseSpeed;
                }
                Destroy (this.gameObject);
            } else if (player.GetComponent<Player>().moveSpeed < 10f)
            {
                Destroy (this.gameObject);
            }
            effectCount += Time.deltaTime;
        }
    }

    protected override void GainEffect (Transform target) {
        player = target;
        float speed = player.GetComponent<Player> ().moveSpeed;

        if (speed != 10f && !isTriggered)
        {
            speed = 10f;
            player.GetComponent<Player> ().moveSpeed = speed;
            isTriggered = true;

            this.GetComponent<Collider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
        } else {
            Destroy (this.gameObject);
        }
    }

}