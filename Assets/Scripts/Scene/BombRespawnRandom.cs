using System.Collections.Generic;
using UnityEngine;

public class BombRespawnRandom : BombRespawn {
    protected override void Update () {

        if (isRespawing) {
            if (countDown >= respawnTime) {
                
                for (int i = 0; i < childCount && parent.childCount < childCount; i++) {
                    var newBomb = Instantiate (bombPrefab, childrenPositions[i], Quaternion.identity);
                    newBomb.transform.parent = parent;
                    newBomb.SetActive (true);
                    if (newBomb.GetComponent<UnitStatus>() != null)
                    {
                        newBomb.GetComponent<UnitStatus>().enabled = true;
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