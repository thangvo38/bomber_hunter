using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Image[] arrImage = new Image[5];

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
        handleKeyboard();
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
    }

    private void enableSpriteBoom()
    {
        for (int i = 0; i < 5; i++)
        {
            arrImage[i].enabled = false;
        }
        arrImage[this.index].enabled = true;
    }
}
