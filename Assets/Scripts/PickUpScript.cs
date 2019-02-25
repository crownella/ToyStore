using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameManager gM;
    public GameObject gO;
    public Rigidbody rB;
    public GameObject player;

    public bool holding = false;
    // Start is called before the first frame update

    private void Start()
    {
        rB = gO.GetComponent<Rigidbody>();
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
                    gO.transform.parent = player.transform;
                    gM.message.text = ("Press E to Drop");
                    rB.useGravity = false;
                    gM.holdingObject = true;
                    holding = true;

                }
                else
                {
                    gO.transform.parent = null;
                    gM.message.text = ("");
                    rB.useGravity = true;
                    gM.holdingObject = false;
                    holding = false;
                }
            
            }
        }
        
    }

    private void OnMouseExit()
    {
        gM.message.text = ("");
    }
}
