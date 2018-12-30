using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UnlockDoorLogic : MonoBehaviour {

	protected int initialEnemies;
	protected bool clearFirstPhrase = false;
	public List<GameObject> ToUnlockDoor;
	public List<Transform> Doors;
	protected virtual void Start () {
		initialEnemies = ToUnlockDoor.Count;
	}
	
	protected virtual void Update () {
		if (!clearFirstPhrase 
			&& initialEnemies > 0 
			&& (ToUnlockDoor.Count == 0 || Services.CheckListAllNull(ToUnlockDoor))) 
		{
			clearFirstPhrase = true;
			foreach(Transform door in Doors)
			{
				Destroy(door.gameObject);
			}
		}
	}

}
