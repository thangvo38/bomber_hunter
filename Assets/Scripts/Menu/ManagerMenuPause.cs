using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMenuPause : MonoBehaviour
{
    public GameObject MenuPause;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        handleKeyboard();
    }

    private void handleKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPause.SetActive(!MenuPause.active);
            if(MenuPause.active)
            {
                Statics.isPause = true;
            }
            else
            {
                Statics.isPause = false;
            }

        }
    }
}
