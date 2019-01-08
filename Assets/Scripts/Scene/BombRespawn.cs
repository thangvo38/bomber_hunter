using System.Collections.Generic;
using UnityEngine;

public class BombRespawn : MonoBehaviour {

    public Transform parent;
    public GameObject bombPrefab;
    public float respawnTime = 5f;
    protected List<Vector2> childrenPositions;
    public int defaultBombLength = -1;
    public bool waitUntilEmpty = true;

    protected float countDown = 0;
    protected int initialCount = 0;
    protected int childCount = 0;

    protected bool isRespawing = false;

    protected virtual void Awake () {
        childCount = parent.childCount;
        initialCount = childCount;
        childrenPositions = new List<Vector2> ();

        for (int i = 0; i < childCount; i++) {
            parent.GetChild (i).gameObject.SetActive (true);
            childrenPositions.Add (parent.GetChild (i).position);
        }
    }

    protected virtual void Update () {

        if (waitUntilEmpty) {
            if (parent.childCount == 0) {
                isRespawing = true;
            }
        } else {
            if (parent.childCount < initialCount) {
                isRespawing = true;
            }
        }

        if (isRespawing) {
            if (countDown >= respawnTime) {
                for (int i = 0; i < childCount && parent.childCount < childCount; i++) {
                    var newBomb = Instantiate (bombPrefab, childrenPositions[i], Quaternion.identity);
                    newBomb.transform.parent = parent;
                    newBomb.SetActive (true);
                    if (newBomb.GetComponent<UnitStatus> () != null) {
                        newBomb.GetComponent<UnitStatus> ().enabled = true;
                    }

                    if (defaultBombLength > 0) {
                        newBomb.GetComponent<BombClassic> ().length = defaultBombLength;
                    }
                }

                isRespawing = false;
                countDown = 0f;
                return;
            }

            countDown += Time.deltaTime;
        }
    }

}