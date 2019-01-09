using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_options : MonoBehaviour {

    public GameObject MenuOptions;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        handleKeyboard();
	}

    private void handleKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            MenuOptions.SetActive(false);
        }
    }
}
