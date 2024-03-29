﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ErasedMenu : MonoBehaviour
{
    public Image[] arrImage = new Image[2];
    private int index = 0;
    public GameObject thisPopup;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        enableSpriteBoom();
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
        if (Input.GetButtonDown("Submit"))
        {
            if (index == 0)
            {
                // Xu ly yes
                Statics.currentFile = index + 1;
                SceneManager.LoadScene("Stage01");
            }
            if (index == 1)
            {
                //Xu ly no
                thisPopup.SetActive(false);
            }
        }
    }

    private void enableSpriteBoom()
    {
        for (int i = 0; i < arrImage.Length; i++)
        {
            arrImage[i].enabled = false;
        }
        arrImage[index].enabled = true;
    }
}
