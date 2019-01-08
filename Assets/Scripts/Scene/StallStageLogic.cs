using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StallStageLogic : MonoBehaviour {
    public int timeInSeconds;
    public string nextScene;
    Text timerUI;
    float timer;
    void Awake () {
        timer = timeInSeconds;
        timerUI = GameObject.Find ("Timer").GetComponent<Text> ();
    }
    void Update () {
        if (timeInSeconds > 0) {
            timer -= Time.deltaTime;
            timeInSeconds = Convert.ToInt32 (timer % 60);
            timerUI.text = timeInSeconds.ToString ();
        } else {
            SceneManager.LoadScene (nextScene);
        }
    }
}