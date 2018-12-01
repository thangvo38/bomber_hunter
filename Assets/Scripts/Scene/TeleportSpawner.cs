using System.Collections.Generic;
using UnityEngine;

public class TeleportSpawner : MonoBehaviour {
    public Transform destructableContainer;
    public GameObject teleport;

    public string nextScene;

    private void Awake() {
        if (teleport != null)
        {
            teleport.GetComponent<Teleport>().nextScene = nextScene;
        }

        int childCount = destructableContainer.childCount;
        if (childCount > 0)
        {
            int index = Random.Range(0, childCount);
            Transform child = destructableContainer.GetChild(index);
            child.GetComponent<Destructable>().dropItems = new List<GameObject>();
            child.GetComponent<Destructable>().dropItems.Add(teleport);
            child.GetComponent<Destructable>().dropRate = 100f;
            Debug.Log("Teleport is in:" + index);
        }
    }
}