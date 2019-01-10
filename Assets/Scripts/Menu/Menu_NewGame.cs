using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_NewGame : MonoBehaviour {
    public Image[] arrImage = new Image[3];
    private int index = 0;
    public GameObject MenuNewGame;
    public GameObject Erased_Menu;
    // Start is called before the first frame update
    void Start () {
        enableSpriteBoom ();
        index = 0;
    }

    // Update is called once per frame
    void Update () {
        handleKeyboard ();
    }

    private void handleKeyboard () {
        if (Input.GetKeyDown (KeyCode.DownArrow)) {
            index += 1;
            if (index > 2)
                index = 0;
            enableSpriteBoom ();
        }
        if (Input.GetKeyDown (KeyCode.UpArrow)) {
            index -= 1;
            if (index < 0)
                index = 2;
            enableSpriteBoom ();
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            if (index >= 0 && index <= 2)
            {
                //Xu ly kiem tra game do co du lieu chua
                Erased_Menu.SetActive(true);
                //Statics.currentFile = index + 1;
                //SceneManager.LoadScene("Stage01");
            }
        }
        if (Input.GetKeyDown (KeyCode.Escape)) {
            MenuNewGame.SetActive (false);
            Erased_Menu.SetActive(false);
        }
    }

    private void enableSpriteBoom () {
        for (int i = 0; i < 3; i++) {
            arrImage[i].enabled = false;
        }
        arrImage[this.index].enabled = true;
    }
}