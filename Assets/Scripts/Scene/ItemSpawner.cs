using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public Transform destructableContainer;
    public GameObject teleport;
    public List<GameObject> items;
    public bool SpawnTeleport = false;
    public string nextScene;

    private void Awake () {
        if (teleport != null) {
            teleport.GetComponent<Teleport> ().nextScene = nextScene;
        }

        int teleportIndex = -1;
        int childCount = destructableContainer.childCount;

        if (SpawnTeleport) {
            if (childCount > 0) {
                int index = Random.Range (0, childCount);
                Transform child = destructableContainer.GetChild (index);
                child.GetComponent<Destructable> ().dropItems = new List<GameObject> ();
                child.GetComponent<Destructable> ().dropItems.Add (teleport);
                child.GetComponent<Destructable> ().dropRate = 100f;
                Debug.Log ("Teleport is in:" + index);
                teleportIndex = index;
            }
        }

        for (int i = 0; i < childCount && items.Count > 0; i++) {
            if (i == teleportIndex)
                continue;

            int itemIndex = Random.Range (0, items.Count);
            Transform child = destructableContainer.GetChild (i);
            child.GetComponent<Destructable> ().dropItems = new List<GameObject> ();
            child.GetComponent<Destructable> ().dropItems.Add (items[itemIndex]);
            child.GetComponent<Destructable> ().dropRate = Random.Range (10f, 20f);
        }

    }
}