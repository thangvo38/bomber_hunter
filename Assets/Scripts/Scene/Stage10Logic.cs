using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage10Logic : MonoBehaviour {

    public Transform parent;
    List<Transform> targets = new List<Transform> ();
    public string nextScene = "Stage11";
    void Awake () {
        int count = parent.childCount;
        for (int i = 0; i < count; i++) {
            targets.Add (parent.GetChild (i));
        }
    }

    // Update is called once per frame
    void Update () {
        if (Services.CheckListAllNull (targets))
            SceneManager.LoadScene (nextScene);
    }
}