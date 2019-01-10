using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_options : MonoBehaviour {

    public GameObject MenuOptions;

    public GameObject Slider;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        handleKeyboard ();
        Statics.CurrentVolume = Slider.GetComponent<Slider>().value;
    }

    private void handleKeyboard () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            MenuOptions.SetActive (false);
        }

        float dir = Input.GetAxisRaw("Horizontal") / 100;
        if (dir > 0)
            Slider.GetComponent<Slider>().value = Mathf.Min(1, Slider.GetComponent<Slider>().value + dir);
        else
            Slider.GetComponent<Slider>().value = Mathf.Max(-1, Slider.GetComponent<Slider>().value + dir);
            
    }
}