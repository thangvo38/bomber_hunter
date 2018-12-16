using System.Collections;
using UnityEngine;

public class ItemBase : MonoBehaviour {

    float turn = 1f;
    public float turnSpeed = 3f;

    void OnValidate () {
        turnSpeed = Mathf.Max (turnSpeed, 0f);
    }
    
    protected virtual void Update () {

    }

    protected virtual void FixedUpdate () {
        Rotate ();
    }

    protected virtual void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GainEffect (other.transform);
        }
    }

    protected virtual void GainEffect (Transform target) { }

    void Rotate () {
        Vector3 scale = this.transform.localScale;
        if (this.transform.localScale.x >= 1f) {
            turn = -1f;
        } else
        if (this.transform.localScale.x <= -1f) {
            turn = 1f;
        }

        float amount = turnSpeed * turn * Time.deltaTime;
        scale.x = Mathf.Abs (scale.x + amount) >= 1 ? turn : scale.x + amount;
        this.transform.localScale = scale;
    }
}