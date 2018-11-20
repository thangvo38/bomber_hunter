using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckCollide : MonoBehaviour {

	public bool isCollided = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
			case "Bomb":
				isCollided = true;
				break;
			default:
				break;
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
			case "Bomb":
				isCollided = true;
				break;
			default:
				break;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		switch(other.gameObject.tag)
		{
			case "Bomb":
				isCollided = false;
				break;
			default:
				break;
		}
	}
}
