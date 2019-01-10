using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFileStatusManager : MonoBehaviour
{

    public Transform loadParent;
    public Transform newParent;

    List<Transform> loadText = new List<Transform>();
    List<Transform> newText = new List<Transform>();

    void Start()
    {
        int count = loadParent.childCount;
        for (int i = 0; i < count; i++)
        {
            loadText.Add(loadParent.GetChild(i));
            newText.Add(loadParent.GetChild(i));
        }

        for (int i = 0; i < loadText.Count; i++)
        {
            SaveData file = SaveSystem.LoadGame(i + 1);
            string status = "";

            if (file == null)
                status = "Empty";
            else
            {
                string[] stageNumber = file.stageName.Split(new string[] {"Stage"}, System.StringSplitOptions.None);
                status = Int32.Parse(String.Join("", stageNumber)).ToString() + "/" + "12";
            }

            loadText[i].GetComponent<TextMeshProUGUI>().text = status;
            newParent.GetChild(i).GetComponent<TextMeshProUGUI>().text = status;
        }
    }

    void Update()
    {

    }
}