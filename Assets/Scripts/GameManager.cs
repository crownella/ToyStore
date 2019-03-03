using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text message;
    public bool holdingObject;
    public GameObject CraftingMenu;
    public bool locked;
    public Transform spawn;

    public GameObject cube;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        CraftingMenu.SetActive(false);
        locked = true;


    }

    // Update is called once per frame
    void Update()
    {
        if(locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        //message.text = ("Test");
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CraftingMenu.activeSelf == true)
            {
                CraftingMenu.SetActive(false);
                locked = true;
            }
            else
            {
                CraftingMenu.SetActive(true);
                locked = false;
            }
        }
    }

    public void OpenPackage(GameObject Package)
    {
        spawn = Package.transform;
        Destroy(Package);
        Instantiate(cube, spawn.position, spawn.rotation);
        Instantiate(cube, spawn.position, spawn.rotation);
        Instantiate(cube, spawn.position, spawn.rotation);
    }
}
