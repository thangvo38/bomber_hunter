using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadPlayer : MonoBehaviour {
    
    GameObject player;

    public int startingLives = 3;

    public bool setStartingLives = false;
    void Start()
    {
        player = GameObject.Find("Player");
        if (setStartingLives)
            player.GetComponent<Player>().lives = startingLives;
            
        Player info = player.GetComponent<Player>();
        SaveSystem.SaveGame(info.lives, info.bombs.Count, SceneManager.GetActiveScene().name, Statics.currentFile);
    }
}