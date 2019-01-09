using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_options : MonoBehaviour {

    public Image[] arrImage = new Image[2];
    private int index = 0;
    public GameObject MenuOptions;
    // Use this for initialization
    void Start () {
        arrImage[1].enabled = false;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                //On Music
            }
            if (index == 1)
            {
                //Off Music
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuOptions.SetActive(false);
        }
    }

        private void enableSpriteBoom()
    {
        if (index == 0)
        {
            arrImage[0].enabled = true;
            arrImage[1].enabled = false;
        }
        else if (index == 1)
        {
            arrImage[0].enabled = false;
            arrImage[1].enabled = true;
        }
    }
}
