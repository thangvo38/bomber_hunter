using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour {
    Player player;
    Text lives;

    void Start () {
        player = GameObject.Find ("Player").GetComponent<Player> ();
        lives = GameObject.FindGameObjectWithTag ("Lives").GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update () {
        setText (player.lives.ToString ());
    }

    public void setText (string txt) //method to set our first image
    {
        lives.text = txt;
    }
}