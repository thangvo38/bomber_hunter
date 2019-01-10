using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombBehavior : MonoBehaviour {
    protected GameObject player;
    public GameObject explosionPrefab;
    public float countDown = 2f;
    public int damage = 1;
    protected int maxLength = 2;
    public bool isTriggered = false;
    // Use this for initialization
    AudioClip explosionSound;
    protected virtual void Awake () {
        explosionSound = Resources.Load ("Audio/Explosion6") as AudioClip;
    }
    protected void Start () { }

    // Update is called once per frame
    protected virtual void Update () {
        if (!Statics.isPause) {
            if (countDown <= 0f && !isTriggered) {
                isTriggered = true;
                PlayAudio ();
                Explode (this.transform.position);
                this.transform.gameObject.GetComponent<Collider2D> ().enabled = false;
                this.transform.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
                // Destroy(gameObject);
            }
            countDown -= Time.deltaTime;
        }
    }

    protected virtual bool ExplodeCell (Vector3Int direction, int currentLength = 1) {
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

    public virtual void SetLength (int newLength) {
        maxLength = newLength;
    }

    void OnTriggerEnter2D (Collider2D other) {
        // Debug.Log(other);
        if (other.gameObject.tag == "Explosion") {
            isTriggered = false;
            countDown = 0f;
            return;
        }
    }

    void OnCollisionStay2D (Collision2D other) {
        Debug.Log (other);
        if (other.gameObject.tag == "Explosion") {
            isTriggered = false;
            countDown = 0f;
            return;
        }
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            GetComponent<BoxCollider2D> ().isTrigger = false;
            other.gameObject.GetComponent<Player> ().canAttack = true;
            return;
        }
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.tag == Constants.PLAYER_TAG) {
            other.gameObject.GetComponent<Player> ().canAttack = false;
            // return;
        }

        if (other.gameObject.tag == "Explosion") {
            countDown = 0f;
            // return;
        }
    }

    void PlayAudio () {
        AudioSource audioSource = GetComponent<AudioSource> ();
        // if (audioSource == null)
        //     audioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;

        // audioSource.clip = explosionSound;
        // audioSource.PlayOneShot(explosionSound, 1);
        audioSource.Play ();
    }
}