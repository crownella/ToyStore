using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBelt : MonoBehaviour
{
    public AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "Package")
        {
            if (!aS.isPlaying)
            {
                aS.Play();
            }

            other.transform.position += Vector3.back * Time.deltaTime;
        }
    }

}
