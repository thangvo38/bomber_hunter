using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMenuPause : MonoBehaviour
{
    public GameObject MenuPause;
    public GameObject YesNoPopup;
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
        if (Input.GetButtonDown("Cancel"))
        {
            MenuPause.SetActive(!MenuPause.active);
            YesNoPopup.SetActive(false);
            if (MenuPause.active)
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
