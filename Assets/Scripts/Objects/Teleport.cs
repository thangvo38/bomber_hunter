using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {
    public string nextScene;

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            //Add animation here

            //Move to next scene
            if (!string.IsNullOrEmpty (nextScene)) {
                SceneManager.LoadScene (nextScene);
            }
        }
    }
}