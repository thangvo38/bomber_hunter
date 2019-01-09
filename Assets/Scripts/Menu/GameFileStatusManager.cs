using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFileStatusManager : MonoBehaviour {

	public Transform loadParent;
	public Transform newParent;

	List<Transform> loadText = new List<Transform>();
	List<Transform> newText = new List<Transform>();

	void Start () {
		int count = loadParent.childCount;
		for (int i = 0; i < count ; i++)
		{
			loadText.Add(loadParent.GetChild(i));
			newText.Add(loadParent.GetChild(i));
		}



		for (int i = 0; i < loadText.Count ; i++)
		{
			SaveData file = SaveSystem.LoadGame(i + 1);
			string status = "";
			if (file == null)
				status = "0/12";
			else {
				status = file.stageName + "/" + "12";
			}

			loadText[i].GetComponent<TextMeshProUGUI>().text = status;
			newParent.GetChild(i).GetComponent<TextMeshPro>().text = status;
		}
	}
	
	void Update () {
		
	}
}
