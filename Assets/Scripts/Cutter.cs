using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public GameObject smallCube;
    public GameObject miniCube;
    public Quaternion rotation;
    public Vector3 position;

    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Cube")
        {
            rotation = other.transform.rotation;
            position = other.transform.position;
            Instantiate(smallCube, position, rotation);
            Instantiate(smallCube, position, rotation);
            Instantiate(smallCube, position, rotation);
            Instantiate(smallCube, position, rotation);
            Destroy(other.gameObject);
        }
        
    }
}
