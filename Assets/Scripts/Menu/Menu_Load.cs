using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Load : MonoBehaviour {

    public Image[] arrImage = new Image[3];
    private int index = 0;
    public GameObject MenuLoad;

    // Use this for initialization
    void Start () {
        enableSpriteBoom();
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
            if (index > 1)
                index = 0;
            enableSpriteBoom();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index -= 1;
            if (index < 0)
                index = 1;
            enableSpriteBoom();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(index == 0)
            {
                //Load game 1
            }
            if (index == 1)
            {
                //Load game 2
            }
            if (index == 2)
            {
                //Load Game 3
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
