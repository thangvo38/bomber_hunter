using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public LayerMask layerMask;
    bool isBlocked = false;
    bool isDestroyWhenHit = false;
    public float duration = 0.75f;

    void Awake () {
        Collider2D hitCollider = Physics2D.OverlapBox (gameObject.transform.position, transform.localScale / 2, 0f, layerMask);
        //Check when there is a new collider coming into contact with the box
        if (hitCollider != null) {
            switch (hitCollider.tag) {
                case "Block":
                    isBlocked = true;
                    Destroy (gameObject);
                    return;
                case "Destructable":
                    isDestroyWhenHit = true;
                    Destroy (hitCollider.gameObject);
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
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (!isBlocked) {
            duration -= Time.deltaTime;
            if (duration <= 0f) {
                //Put Fade out animation here
                Destroy (this.transform.parent.gameObject);
            }
        }
    }

    public bool allowNextExplosion () {
        return !isBlocked && !isDestroyWhenHit;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(!isBlocked)
        {
            switch(other.gameObject.tag)
            {
                case "Player":
                case "Enemy":
                    other.transform.GetComponent<UnitStatus>().Damage();
                    break;
            }
        }
    }
}