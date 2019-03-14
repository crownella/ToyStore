using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameManager gM;
    public Rigidbody rB;
    public GameObject objectPlaceholder;
    private ObjectManager oM;

    public bool holding = false;
    // Start is called before the first frame update

    private void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        objectPlaceholder = GameObject.FindWithTag("Item");
        

    }

    private void Update()
    {
        /*
        if (holding)
        {
            //position = objectPlaceholder.transform.position;
            transform.SetParent(objectPlaceholder.transform);
            rB.useGravity = false;
            gM.holdingObject = true;
            gM.objectBeingHeld = gameObject;
            rB.isKinematic = true;
            rB.constraints = RigidbodyConstraints.FreezeRotation;
            rB.mass = 0;

        }
        else
        {
            transform.SetParent(null);
            rB.useGravity = true;
            gM.holdingObject = false;
            gM.objectBeingHeld = null;
            rB.isKinematic = false;
            rB.constraints = RigidbodyConstraints.None;
            rB.mass = 1;
            
        }
        */
    }

    

    public void PickUp(GameObject other)
    {
        if (gM.holdingObject == false)
        {
            rB = other.GetComponent<Rigidbody>();
            oM = other.GetComponent<ObjectManager>();
            
            other.transform.SetParent(objectPlaceholder.transform);
            rB.useGravity = false;
            rB.mass = 0;
            rB.isKinematic = true;
            rB.constraints = RigidbodyConstraints.FreezeRotation;
            gM.holdingObject = true;
            oM.beingHeld = true;
            gM.objectBeingHeld = other.gameObject;

        } 
    }

    public void DropObject(GameObject other)
    {
        if (gM.holdingObject)
        {
            rB = other.GetComponent<Rigidbody>();
            oM = other.GetComponent<ObjectManager>();
            
            other.transform.SetParent(null);
            gM.holdingObject = false;
            rB.useGravity = true;
            rB.isKinematic = false;
            rB.constraints = RigidbodyConstraints.None;
            oM.beingHeld = true;
            rB.mass = oM.objectMass;
            gM.objectBeingHeld = null;
        }
    }
}
