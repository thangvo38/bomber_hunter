using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour {

    public List<Transform> targets;
    public string nextScene;

    void Update () {
        if ((Services.CheckListAllNull (targets) || targets.Count == 0) && !string.IsNullOrEmpty (nextScene)) {
            SceneManager.LoadScene (nextScene);
            return;
        }
    }
}