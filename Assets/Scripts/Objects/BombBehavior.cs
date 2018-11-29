using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombBehavior : MonoBehaviour {
    public GameObject explosionPrefab;
    public float countDown = 2f;
    public int damage = 1;
    protected int maxLength = 0;
    bool isTriggered = false;
    // Use this for initialization
    protected void Start () {
        isTriggered = false;
    }

    // Update is called once per frame
    protected void Update () {

        if (countDown <= 0f && !isTriggered) {
            isTriggered = true;
            Explode (this.transform.position);
            this.transform.gameObject.GetComponent<Collider2D> ().enabled = false;
            this.transform.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
            // Destroy(gameObject);
        }

        countDown -= Time.deltaTime;
    }

    protected bool ExplodeCell (Vector3Int direction, int currentLength = 1) {
        if (currentLength >= this.maxLength) {
            return false;
        }

        Vector3 pos = this.transform.position + direction;
        GameObject explosion = (GameObject) Instantiate (explosionPrefab, pos, Quaternion.identity, this.transform);
        bool allowNextExplosion = explosion.GetComponent<Explosion> ().allowNextExplosion ();
        if (!allowNextExplosion || currentLength == 0) {
            return false;
        } else {
            return ExplodeCell (Services.ToVectorOne (direction) * (currentLength + 1), currentLength + 1);
        }
    }
    public virtual void Explode (Vector2 position) { }

    void OnTriggerEnter2D (Collider2D other) {
        // Debug.Log(other);
        if (other.gameObject.tag == "Explosion") {
            Debug.Log ("BBBB");
            countDown = 0f;
            return;
        }
    }

    void OnCollisionStay2D (Collision2D other) {
        Debug.Log (other);
        if (other.gameObject.tag == "Explosion") {
            Debug.Log ("BBBB");
            countDown = 0f;
            return;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GetComponent<BoxCollider2D> ().isTrigger = false;
            other.gameObject.GetComponent<Player> ().canAttack = true;
            return;
        }
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Player> ().canAttack = false;
            // return;
        }

        if (other.gameObject.tag == "Explosion") {
            Debug.Log ("AAAAA");
            countDown = 0f;
            // return;
        }
    }
}