using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBelt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "Package")
        {
            other.transform.position += Vector3.forward * Time.deltaTime;
        }
    }
}
