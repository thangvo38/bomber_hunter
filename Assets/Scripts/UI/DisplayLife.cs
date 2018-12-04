using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLife : MonoBehaviour {
    Image myImageComponent;
    public Sprite Image0;
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Player player;                                 
    void Start () {
        myImageComponent = GameObject.FindGameObjectWithTag("Lives").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        if (player.lives == 3)
        {
            SetImage(Image3);
        }
        else if (player.lives == 2)
        {
            SetImage(Image2);
        }
        else if (player.lives == 1)
        {
            SetImage(Image1);
        }
        else SetImage(Image0);

    }

    public void SetImage(Sprite image) //method to set our first image
    {
        myImageComponent.sprite = image;
    }
}
