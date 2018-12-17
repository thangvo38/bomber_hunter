using System.Collections.Generic;
using UnityEngine;

public class BombRespawn : MonoBehaviour {

    public Transform parent;
    public GameObject bombPrefab;
    public float respawnTime = 5f;
    List<Vector2> childrenPositions;

    float countDown = 0;

    int childCount = 0;

    bool isRespawing = false;

    void Awake () {
        childCount = parent.childCount;
        childrenPositions = new List<Vector2> ();

        for (int i = 0; i < childCount; i++) {
            parent.GetChild (i).gameObject.SetActive (true);
            childrenPositions.Add (parent.GetChild (i).position);
        }
    }

    void Update () {
        if (parent.childCount == 0) {
            isRespawing = true;
        }

        if (isRespawing) {
            if (countDown >= respawnTime) {
                for (int i = 0; i < childCount; i++) {
                    var newBomb = Instantiate (bombPrefab, childrenPositions[i], Quaternion.identity);
                    newBomb.transform.parent = parent;
                    newBomb.SetActive (true);
                }

                isRespawing = false;
                countDown = 0f;
                return;
            }

            countDown += Time.deltaTime;
        }
    }

}