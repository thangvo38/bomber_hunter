using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public LayerMask layerMask;
    public float duration = 0.75f;
    protected bool isBlocked = false;
    protected bool isDestroyWhenHit = false;

    protected virtual void Awake () {
        Collider2D hitCollider = Physics2D.OverlapBox (gameObject.transform.position, transform.localScale / 2, 0f, layerMask);
        //Check when there is a new collider coming into contact with the box
        if (hitCollider != null) {
            switch (hitCollider.tag) {
                case Constants.WALL_TAG:
                    isBlocked = true;
                    Destroy (gameObject);
                    return;
                case Constants.DESTRUTABLE_TAG:
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

    // Use this for initialization
    protected virtual void Start () {

    }

    // Update is called once per frame
    protected virtual void Update () {
        if (!Statics.isPause) {
            if (!isBlocked) {
                duration -= Time.deltaTime;
                if (duration <= 0f) {
                    //Put Fade out animation here
                    Destroy (this.transform.parent.gameObject);
                }
            }
        }
    }

    public virtual bool allowNextExplosion () {
        return !isBlocked && !isDestroyWhenHit;
    }

    protected virtual void OnTriggerEnter2D (Collider2D other) {
        if (!isBlocked) {
            switch (other.gameObject.tag) {
                case Constants.PLAYER_TAG:
                case Constants.ENEMY_TAG:
                    other.transform.GetComponent<UnitStatus> ().Damage ();
                    break;
            }
        }
    }
}