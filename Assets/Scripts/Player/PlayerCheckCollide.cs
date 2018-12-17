using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckCollide : MonoBehaviour {

    public bool isCollided = false;

    // Use this for initialization
    void Awake () { }

    // Update is called once per frame
    void Update () { }

    private void OnTriggerEnter2D (Collider2D other) {
        checkEnterStay (other.gameObject.tag);
    }

    private void OnTriggerStay2D (Collider2D other) {
        checkEnterStay (other.gameObject.tag);
    }

    private void OnTriggerExit2D (Collider2D other) {
        checkExit (other.gameObject.tag);
    }

    void checkEnterStay (string tag) {
        switch (tag) {
            case Constants.ENEMY_WALL:
                if (this.transform.parent.tag == "Enemy")
                    isCollided = true;
                break;
            case Constants.BOMB_TAG:
                isCollided = true;
                break;
            case "Explosion":
                isCollided = false;
                break;
            default:
                break;
        }
    }

    void checkExit (string tag) {
        switch (tag) {
            case Constants.ENEMY_WALL:
                if (this.transform.parent.tag == "Enemy")
                    isCollided = false;
                break;
            case Constants.BOMB_TAG:
                isCollided = false;
                break;
            default:
                break;
        }
    }

}