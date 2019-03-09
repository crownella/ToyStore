using System.Collections;
using System.Collections.Generic;
using System.Timers;
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
    public bool computer;
    public bool crafting;

    public GameObject cube;
    
    //ordersystem
    public Text cashValue;
    public float cash;
    public Text currentOrder;
    public OrderManager oM;
    public string order;
    public PackageManager pM;
    
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

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        CraftingMenu.SetActive(false);
        locked = true;
        cash = 20.00f;
        day = 1;
        hours = 12;
        minutes = 0;
        seconds = 0;
        crafting = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Computer")
        {
            computer = true;
            locked = false;
        }
        else
        {
            computer = false;
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
        //message.text = ("Test");
        if (Input.GetKeyDown(KeyCode.C) && computer == false)
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
            locked = false;
        }
        else
        {
            CraftingMenu.SetActive(false);
            locked = true;
        }

        cashValue.text = cash.ToString();
        order = oM.ReturnOrderName();
        currentOrder.text = order;

        if (timer >= timerMod)
        {
            Clock();
            timer = 0;
           
        }
    }

    public void OpenPackage(GameObject Package)
    {
        pM = Package.GetComponent<PackageManager>();
        spawn = Package.transform;
        Destroy(Package);
        Instantiate(cube, spawn.position, spawn.rotation);
        Instantiate(cube, spawn.position, spawn.rotation);
        Instantiate(cube, spawn.position, spawn.rotation);
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
