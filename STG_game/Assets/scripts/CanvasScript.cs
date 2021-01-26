using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public PickUpObjects PUO;
    public GameObject Parent; // Enable or disable everything with this object
    // UI items to be manipulated
    public Transform ThrowBar;
    public Transform MaxThrowBar;

    public void Update(){
        bool ch = PUO.canHold;

        // Enable or disable throwing UI when player is holding item
        if (ch == false){
            Parent.SetActive(true);
            throwUI();
        }
        else{
            Parent.SetActive(false);
        }

    }

    void throwUI(){
        float thrSpd = PUO.throwSpeed;
        float mxThrSpd = PUO.maxThrowSpeed;
        // Set sizes
        ThrowBar.localScale = new Vector3(thrSpd / 5, .25f, 1f);
        MaxThrowBar.localScale = new Vector3(mxThrSpd / 5, .25f, 1f);
    }
}
