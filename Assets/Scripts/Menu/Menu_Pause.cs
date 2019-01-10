using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Pause : MonoBehaviour
{
    public Image[] arrImage = new Image[2];
    private int index = 0;
    public GameObject MenuPause;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index == 0)
            {
                //Resume
                MenuPause.SetActive(false);
                Statics.isPause = false;
            }
            if (index == 1)
            {
                SceneManager.LoadScene("Menu");
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
