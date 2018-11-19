using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombBehavior : MonoBehaviour {
	public Tilemap tilemap;
	public GameObject explosionPrefab;
	public float countDown = 2f;
	public int damage = 1;
	protected int maxLength = 0;
	bool isTriggered = false;
	// Use this for initialization
	protected void Start () {
		isTriggered = false;
	}
	
	// Update is called once per frame
	protected void Update () {
		
		if (countDown <= 0f && !isTriggered)
		{
			isTriggered = true;
			Explode(this.transform.position);
			Destroy(gameObject);
		}

		countDown -= Time.deltaTime;
	}

	protected bool ExplodeCell(Vector3Int cellPos, Vector3Int direction, int currentLength = 1)
	{
		if (currentLength >= this.maxLength)
		{
			return false;
		}

		Vector3 pos = tilemap.GetCellCenterWorld(cellPos + direction);
		GameObject explosion = (GameObject)Instantiate(explosionPrefab, pos, Quaternion.identity);
		bool isBlocked = explosion.GetComponent<Explosion>().isBlocked;
		if (isBlocked || currentLength == 0)
		{
			return false;
		} else {
			return ExplodeCell(cellPos, new Services().ToVectorOne(direction) * (currentLength + 1), currentLength + 1);
		}
	}
	protected virtual void Explode(Vector2 position)
	{
	}
}
