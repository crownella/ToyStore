using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameManager gM;
    //public MainSceneManager mM;
    public Rigidbody rB;
    public GameObject objectPlaceholder;
    public bool rotated = false;
    public Vector3 position;
    public CraftingStation cS;
    public bool onTable = false;
    public bool inPackage = false;
    public inPackageManager iPM;
    

    public bool holding = false;
    // Start is called before the first frame update

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        objectPlaceholder = GameObject.FindWithTag("Item");
        cS = GameObject.FindWithTag("Craft").GetComponent<CraftingStation>();
        //mM = GameObject.FindGameObjectWithTag("MM").GetComponent<MainSceneManager>();

    }

    private void Update()
    {
        if (holding == true)
        {
            //position = objectPlaceholder.transform.position;
            transform.SetParent(objectPlaceholder.transform);
            rB.useGravity = false;
            gM.holdingObject = true;
            rB.isKinematic = true;
            rB.constraints = RigidbodyConstraints.FreezeRotation;
            rB.mass = 0;

        }
        else
        {
            transform.SetParent(null);
            rB.useGravity = true;
            gM.holdingObject = false;
            rB.isKinematic = false;
            rB.constraints = RigidbodyConstraints.None;
            rB.mass = 1;
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Craft" && onTable == false)
        {
            cS = other.transform.GetComponent<CraftingStation>();
            cS.AddtoList(this.gameObject);
            onTable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EmptyPackage" && inPackage == false)
        {
            iPM = other.transform.GetComponent<inPackageManager>();
            iPM.addItem(this.gameObject);
            inPackage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "EmptyPackage" && inPackage == true)
        {
            iPM = other.transform.GetComponent<inPackageManager>();
            iPM.removeItem(this.gameObject);
            inPackage = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Craft" && onTable == true)
        {
            cS = other.transform.GetComponent<CraftingStation>();
            cS.RemoveItem(this.gameObject);
            onTable = false;
        }
    }
}
