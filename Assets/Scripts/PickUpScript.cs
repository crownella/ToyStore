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
                    gM.message.text = ("holding");

                }
                else
                {
                    gM.message.text = ("dropped");
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
            if (gO.tag == "Rotate" && rotated == false)
            {
                //gO.transform.Rotate(0,0,90);
                //rotated = true;
                //Debug.Log("Rotated");
            }
        }
        else
        {
            rB.useGravity = true;
            gM.holdingObject = false;
            if (gO.tag == "Rotate" && rotated == true)
            {
               // gO.transform.Rotate(0,0,0);
                //rotated = false;
                //Debug.Log("Not Rotated");
            }
        }
    }

    private void OnMouseExit()
    {
        gM.message.text = ("");
    }
}
