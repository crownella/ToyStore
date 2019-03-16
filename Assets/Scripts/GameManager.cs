using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Internal.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    


    public bool computer;
    public float cash;

    public GameObject cube;
    public GameObject nails;
    public GameObject gunPOw;


    public bool carUnlocked;
    public bool eCarUnlocked;

    public bool gameLost;
    public bool gameWon;
    



    

    
    //time
    public int day;
    public int hours;
    public int minutes;
    public int seconds;
    public Text dayT;
    public Text hoursT;
    public Text minutesT;
    public Text secondsT;

    public int timer;
    public int timerMod;

    public bool itemOrdered;
    public List<GameObject> orderedItems = new List<GameObject>();
    
    //imported from main scene
    public bool crafting;
    public Text message;

    public GameObject CraftingMenu;
    public bool locked;

    //ordersystem
    public Text cashValue;
    public Text currentOrder;
    public OrderManager oM;
    public string order;
    public PackageManager pM;

    private GameObject _currentPackage;
    public GameObject packageObject;
    public Transform packageSpawn;

    public GameObject carBlueprint;
    public GameObject eCarBlueprint;

 

    public GameObject spawnedObject;
    public bool gameOver;
    public Text gameOvert;

    public GameObject computerCanvas;
    public GameObject uICanvas;
    
    public Text packageNoti;
    public GameObject objectBeingHeld;
    public bool holdingObject = false;

    public bool packageOpended = true;

    public AudioSource packageAudio;
    public AudioClip packageA;
    

    public AudioSource Door;
    public AudioClip knock;
    public bool knocked;

    public CraftingStation cS;
   
  

    // Start is called before the first frame update
    
    void Start()
    {
        
        
        //DontDestroyOnLoad(this);
        locked = true;
        holdingObject = false;
        carBlueprint.SetActive(false);
        eCarBlueprint.SetActive(false);
        day = 1;
        hours = 12;
        minutes = 0;
        seconds = 0;
        computer = true;
        packageOpended = true;



    }

    // Update is called once per frame
    void Update()
    {  
        if (computer || crafting)
        {
            locked = false;
            packageNoti.text = "";
        }
        if (computer == false && crafting == false)
        {
            locked = true;
        }
        if (computer)
        {
            computerCanvas.SetActive(true);
            uICanvas.SetActive(false);
        }
        else
        {
            computerCanvas.SetActive(false);
            uICanvas.SetActive(true);
        } 
        if(locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //if (timer >= timerMod)
        //{
           // Clock();
           // timer = 0;
           
        //}
        //dayT.text = day.ToString();
        //hoursT.text = hours.ToString();
        //minutesT.text = minutes.ToString();
        //secondsT.text = seconds.ToString();
        
        //imported from update
        //end conditons
        if (gameOver == true)
        {
            gameOvert.text = "Someones knocking at the door";
            Door.clip = knock;
            if (!knocked)
            {
                Door.Play();
                knocked = true;
            }
        }else
        {
            gameOvert.text = "";
        }
        
        //crafing
        if (Input.GetKeyDown(KeyCode.C) && !computer && !cS.crafting)
        {
            if (crafting)
            {
                crafting = false;
            }
            else
            {
                crafting = true;
            }
        }
        if(crafting)
        {
            CraftingMenu.SetActive(true);
        }
        else
        {
            CraftingMenu.SetActive(false);
        } 
        if (carUnlocked)
        {
            carBlueprint.SetActive(true);
        }
        if (eCarUnlocked)
        {
            eCarBlueprint.SetActive(true);
        }
        //ui setting
        if (computer == false)
        {
            order = oM.ReturnOrderName();
            currentOrder.text = order;
            cashValue.text = cash.ToString();
        }
        if (itemOrdered && computer == false)
        {
            SpawnPackage();
            itemOrdered = false;
        } 
    }
    public void SpawnPackage()
    {
        _currentPackage = Instantiate(packageObject, packageSpawn.position, packageSpawn.rotation);
        pM = _currentPackage.GetComponent<PackageManager>();
        pM.itemsInPackage = orderedItems;        //<--------- is this breaking it????
        packageOpended = false;
    }
    public void OpenPackage(GameObject package)
    {
        packageAudio = package.GetComponent<AudioSource>();
        packageAudio.clip = packageA;
        packageAudio.Play();
        pM = package.GetComponent<PackageManager>();
        for(int i = 0; i < pM.itemsInPackage.Count; i++)
        {
            spawnedObject = Instantiate(pM.itemsInPackage[i], package.transform.position, package.transform.rotation);
            spawnedObject.SetActive(true);
        }
        Destroy(package);
        packageOpended = true;
    }


    public void Clock()
    {
        if (hours == 25)
        {
            hours = 0;
            day += 1;
        }
        if (minutes == 61)
        {
            minutes = 0;
            hours += 1;
        }

        if (seconds == 61)
        {
            seconds = 0;
            minutes += 1;
        }

        seconds += 1;
    }


}
