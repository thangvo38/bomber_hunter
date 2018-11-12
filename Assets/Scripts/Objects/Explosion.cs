using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public LayerMask layerMask;	
	bool isTriggered = false;
	public bool isBlocked = false;

	void Awake()
	{
		Collider2D hitCollider = Physics2D.OverlapBox(gameObject.transform.position, transform.localScale / 2, 0f, layerMask);
		//Check when there is a new collider coming into contact with the box
		if (hitCollider != null)
		{
			if (hitCollider.tag == "Block")
			{
				isBlocked = true;
				Destroy(gameObject);
				return;
			}
		}

		//If isn't blocked
		this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		isBlocked = false;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// void OnTriggerEnter2D(Collider2D other)
	// {
	// 	if (!isTriggered)
	// 	{
	// 		if (other.tag == "Block")
	// 		{
	// 			Destroy(gameObject);
	// 		}
	// 		isTriggered = true;
	// 	}
	// }
}
