using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public float objectMass;
    private CraftingStation cS;
    public bool onTable = false;
    public bool inPackage = false;
    private inPackageManager iPM;

    public bool beingHeld;
    // Start is called before the first frame update
    void Start()
    {
        cS = GameObject.FindWithTag("Craft").GetComponent<CraftingStation>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.tag == "Craft" && onTable == true)
        {
            cS = other.transform.GetComponent<CraftingStation>();
            cS.RemoveItem(this.gameObject);
            onTable = false;
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


    
}
