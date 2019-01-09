using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBomb : MonoBehaviour {

    GameObject player;
    void Start () {
        player = GameObject.Find("Player");
    }

    void Update () {
        int id = player.GetComponent<Player>().curerntBombId;
        var bombList = player.GetComponent<Player>().bombs;
        this.GetComponent<Image>().sprite = bombList[id].GetComponent<SpriteRenderer>().sprite;
    }
}