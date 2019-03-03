using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "EmptyPackage" || other.transform.tag == "Package" || other.transform.tag == "Cube" || other.transform.tag == "MiniCube" || other.transform.tag == "SmallCube" || other.transform.tag == "Block" || other.transform.tag == "Lego")
        {
            Destroy(other.transform.gameObject);
        }
    }
}
