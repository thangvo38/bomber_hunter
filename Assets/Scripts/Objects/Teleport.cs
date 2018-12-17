using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {
    public string nextScene;

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Player") {
            //Add animation here

            //Save game
            GameObject gameManager = GameObject.Find ("GameManager");
            if (gameManager) {
                // gameManager.GetComponent<GameManager>().Save();
            }

            //Move to next scene
            if (!string.IsNullOrEmpty (nextScene)) {
                SceneManager.LoadScene (nextScene);
            }
        }
    }
}