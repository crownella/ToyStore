using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameManager gM;
    public GameObject gO;
    public Rigidbody rB;
    public GameObject objectPlaceholder;
    public bool rotated = false;
    public Vector3 position;
    

    public bool holding = false;
    // Start is called before the first frame update

    private void Start()
    {
        rB = gO.GetComponent<Rigidbody>();
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        objectPlaceholder = GameObject.FindWithTag("Item");

    }

    private void OnMouseOver()
    {
        if (gM.holdingObject == false)
        {
            if (holding == false)
            {
                gM.message.text = ("Press E to Pick Up");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (holding == false)
                {
                    
                    holding = true;

                }
                else
                {
                    holding = false;
                }
            
            }
        }
        
    }

    private void Update()
    {
        if (holding == true)
        {
            position = objectPlaceholder.transform.position;
            gO.transform.position = position;
            gM.message.text = ("Press E to Drop");
            rB.useGravity = false;
            gM.holdingObject = true;
            rB.constraints = RigidbodyConstraints.FreezeRotation;

        }
        else
        {
            rB.useGravity = true;
            gM.holdingObject = false;
            rB.constraints = RigidbodyConstraints.None;
            gM.message.text = ("");
        }
    }

    private void OnMouseExit()
    {
        gM.message.text = ("");
    }
}
