using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public List<GameObject> dropItems;

    [Range (0f, 100f)]
    public float dropRate = 50f;
    void Start () {

    }

    void Update () {

    }
    public void Damaged () {
        DropItem ();
        Destroy (this.gameObject);
    }

    void DropItem () {
        if (dropItems.Count > 0) {
            float isDropped = Random.Range (0f, 101f);
            if (isDropped <= dropRate) {
                Instantiate (dropItems[Random.Range (0, dropItems.Count)], this.transform.position, Quaternion.identity);
            }
        }
    }
}