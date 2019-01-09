using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Load : MonoBehaviour {

    public Image[] arrImage = new Image[3];
    private int index = 0;
    public GameObject MenuLoad;

    // Use this for initialization
    void Start () {
        enableSpriteBoom();
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
        handleKeyboard();
	}

    private void handleKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index += 1;
            if (index > 2)
                index = 0;
            enableSpriteBoom();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index -= 1;
            if (index < 0)
                index = 2;
            enableSpriteBoom();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch(index)
            {
                case 0:
                case 1:
                case 2:
                {
                    SaveData file = SaveSystem.LoadGame(index + 1);
                    if (file != null)
                    {
                        Statics.currentFile = file.fileNumber;
                        SceneManager.LoadScene(file.stageName);
                    }
                    break;
                }
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuLoad.SetActive(false);
        }
    }

    private void enableSpriteBoom()
    {
        for (int i = 0; i < 3; i++)
        {
            arrImage[i].enabled = false;
        }
        arrImage[this.index].enabled = true;
    }
}
