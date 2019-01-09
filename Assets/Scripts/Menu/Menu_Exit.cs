using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Exit : MonoBehaviour {
    public Image[] arrImage = new Image[2];
    private int index = 0;
    public GameObject MenuExit;

    // Use this for initialization
    void Start () {
        arrImage[1].enabled = false;
        index = 0;
    }

    // Update is called once per frame
    void Update () {
        handleKeyboard ();
    }

    private void handleKeyboard () {
        if (Input.GetKeyDown (KeyCode.DownArrow)) {
            index += 1;
            if (index > 1)
                index = 0;
            enableSpriteBoom ();
        }
        if (Input.GetKeyDown (KeyCode.UpArrow)) {
            index -= 1;
            if (index < 0)
                index = 1;
            enableSpriteBoom ();
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            if (index == 0) {
                //End Game
            }
            if (index == 1) {
                MenuExit.SetActive (false);
            }
        }
    }

    private void enableSpriteBoom () {
        if (index == 0) {
            arrImage[0].enabled = true;
            arrImage[1].enabled = false;
        } else if (index == 1) {
            arrImage[0].enabled = false;
            arrImage[1].enabled = true;
        }
    }
}