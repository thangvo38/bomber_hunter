using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialExplosion : Explosion {
    protected override void Awake () {
        Collider2D hitCollider = Physics2D.OverlapBox (gameObject.transform.position, transform.localScale / 2, 0f, layerMask);
        //Check when there is a new collider coming into contact with the box
        if (hitCollider != null) {
            switch (hitCollider.tag) {
                case "Destructable":
                    isDestroyWhenHit = true;
                    hitCollider.gameObject.GetComponent<Destructable> ().Damaged ();
                    break;
            }
        }

        //If isn't blocked
        if (!isBlocked) {
            this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
            isBlocked = false;
        }
    }
}