using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage12Logic : UnlockDoorLogic {
    public GameObject Boss;
    protected override void Update () {
        base.Update ();
        if (clearFirstPhrase) {
            if (Boss == null)
            {
                SceneManager.LoadScene (Constants.SCENE_END_GAME);
                return;
            }

            if (Boss.activeSelf == false)
                Boss.SetActive (true);

            int hp = Boss.GetComponent<UnitStatus> ().lives;
            if (hp <= 0) {
                //Move to End game screen 
                SceneManager.LoadScene (Constants.SCENE_END_GAME);
                return;
            }
        }
    }
}