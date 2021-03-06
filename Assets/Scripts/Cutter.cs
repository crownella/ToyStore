﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour
{
    public GameObject smallCube;
    public GameObject miniCube;
    public Quaternion rotation;
    public Vector3 position;
    public GameObject buttonOn;
    public GameObject buttonOff;
    public bool on;
    public int rotationSpeed;

    //public string tag;

    public AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        buttonOff.SetActive(true);
        buttonOn.SetActive(false);
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            
            transform.Rotate(0,0,rotationSpeed);
        }
        else
        {
            
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (on)
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
            }else if(other.gameObject.tag == "SmallCube")
            {
                rotation = other.transform.rotation;
                position = other.transform.position;
                Instantiate(miniCube, position, rotation);
                Instantiate(miniCube, position, rotation);
                Instantiate(miniCube, position, rotation);
                Instantiate(miniCube, position, rotation);
                Destroy(other.gameObject);
            }
        }
        
        
    }

    public void TurnOnSaw()
    {
        buttonOff.SetActive(false);
        buttonOn.SetActive(true);
        on = true;
        aS.Play();
    }

    public void TurnOffSaw()
    {
        buttonOff.SetActive(true);
        buttonOn.SetActive(false);
        @on = false;
        aS.Stop();
    }

    
}
