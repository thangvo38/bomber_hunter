using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Image[] arrImage = new Image[5];
    public GameObject ExitMenu;
    public GameObject MenuLoad;
    public GameObject MenuOptions;

    private int index = 0;
    // Use this for initialization
    void Start()
    {
        arrImage[0] = GameObject.FindGameObjectWithTag("NewGame").GetComponent<Image>();
        arrImage[1] = GameObject.FindGameObjectWithTag("Load").GetComponent<Image>();
        arrImage[2] = GameObject.FindGameObjectWithTag("Options").GetComponent<Image>();
        arrImage[3] = GameObject.FindGameObjectWithTag("About").GetComponent<Image>();
        arrImage[4] = GameObject.FindGameObjectWithTag("Exit").GetComponent<Image>();

        for (int i = 1; i < 5; i++)
        {
            arrImage[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasPopupOpen())
        {
            handleKeyboard();
        }
    }

    private void handleKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            index += 1;
            if (index > 4)
                index = 0;
            enableSpriteBoom();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index -= 1;
            if (index < 0)
                index = 4;
            enableSpriteBoom();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (this.index)
            {
                case 0:
                    {
                        //New Game
                    }   
                    break;
                case 1:
                    {
                        MenuLoad.SetActive(true);
                    }
                    break;
                case 2:
                    {
                        MenuOptions.SetActive(true);
                    }
                    break;
                case 3:
                    {
                        //About
                    }
                    break;
                case 4:
                    {
                        ExitMenu.SetActive(true);
                    }
                    break;
            }
        }
    }

    private void enableSpriteBoom()
    {
        for (int i = 0; i < 5; i++)
        {
            arrImage[i].enabled = false;
        }
        arrImage[this.index].enabled = true;
    }

    private bool hasPopupOpen()
    {
        return (ExitMenu.active || MenuLoad.active || MenuOptions.active);
    }
}
