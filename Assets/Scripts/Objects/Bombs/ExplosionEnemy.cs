using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy : Explosion {
    protected override void OnTriggerEnter2D (Collider2D other) {
        if (!isBlocked) {
            switch (other.gameObject.tag) {
                case Constants.PLAYER_TAG:
                    other.transform.GetComponent<UnitStatus> ().Damage ();
                    break;
            }
        }
    }
}