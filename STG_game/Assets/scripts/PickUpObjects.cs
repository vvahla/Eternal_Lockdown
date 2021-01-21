using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{

    public float throwSpeed = 10;

    public bool canHold = true;

    public GameObject pickUp;

    //Helps the pickup to find a place
    public Transform guide;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canHold == false)
                throw_drop();
            else
                Pickup();
        }
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
}
