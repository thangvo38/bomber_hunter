using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	public LayerMask layerMask;	
	bool isTriggered = false;
	public bool isBlocked = false;

	public float duration = 0.75f;
	void Awake()
	{
		Collider2D hitCollider = Physics2D.OverlapBox(gameObject.transform.position, transform.localScale / 2, 0f, layerMask);
		//Check when there is a new collider coming into contact with the box
		if (hitCollider != null)
		{
			if (hitCollider.tag == "Block") {
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
		if (!isBlocked)
		{
			duration -= Time.deltaTime;
			if (duration <= 0f)
			{
				//Put Fade out animation here
				Destroy(this.transform.parent.gameObject);
			}
		}
	}

	// void OnTriggerEnter2D(Collider2D other)
	// {
	// 	if (!isTriggered)
	// 	{
	// 		if (other.tag == "Bomb")
	// 		{
	// 			BombClassic isAnotherBomb = other.gameObject.GetComponent<BombClassic>();

	// 			isAnotherBomb.Explode(this.transform.position);
	// 			Destroy(gameObject);
	// 		}
	// 		isTriggered = true;
	// 	}
	// }
}
