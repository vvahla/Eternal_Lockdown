using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    [Header("Throwing Values")]
    public float throwSpeed;
    public float maxThrowSpeed;
    public float throwMagnitude;

    [Header("Bools")]
    public bool mouseHeld;
    public bool canHold = true;

    [Header("Misc.")]
    public GameObject pickUp;
    //Helps the pickup to find a place
    public Transform guide;

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canHold == false)
                throw_drop();
            else
                Pickup();
        }
        */

        if(canHold == false){
            throw_speed();
        } else if(Input.GetKeyDown(KeyCode.E)) { Pickup(); }

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "pickup")
        {
            if(!pickUp)
                pickUp = col.gameObject;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "pickup")
        {
            if (canHold)
                pickUp = null;
        }
    }

    private void Pickup()
    {
        if (!pickUp)
            return;

        //set the pickup parent to guide
        pickUp.transform.SetParent(guide);

        //gravity off for the pickup
        pickUp.GetComponent<Rigidbody>().useGravity = false;

        //apply main camera rotation
        pickUp.transform.localRotation = transform.rotation;

        //set the position to guide
        pickUp.transform.position = guide.position;

        pickUp.GetComponent<Rigidbody>().isKinematic = true;

        canHold = false;
    }

    private void throw_drop()
    {
        if (!pickUp)
            return;

        pickUp.GetComponent<Rigidbody>().isKinematic = false;

        //Set Gravity to true again.
        pickUp.GetComponent<Rigidbody>().useGravity = true;
        //don't have anything to do with pickUp field anymore
        pickUp = null;
        //Apply velocity on throwing
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * throwSpeed;

        //Unparent pickUp
        guide.GetChild(0).parent = null;
        canHold = true;
    }

    void throw_speed(){
        if(Input.GetMouseButton(0)){
            mouseHeld = true;
        }

        if (mouseHeld == true){
            throwSpeed += throwMagnitude;
        }

        if(Input.GetMouseButtonUp(0) && mouseHeld == true){ // Call throw_drop function and reset values
            throw_drop();
            throwSpeed = 0f;
            mouseHeld = false;
        }

    }
}
