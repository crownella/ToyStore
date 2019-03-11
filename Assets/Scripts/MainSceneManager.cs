using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public GameManager gM;
    public bool crafting = false;
    public Text message;
    public bool holdingObject = false;
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

    private static MainSceneManager _instance;
    public static MainSceneManager Instance
    {
        get { return _instance; }
    }

    public GameObject spawnedObject;
    public bool gameOver;
    public Text gameOvert;

    


    void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        oM = GameObject.FindWithTag("OrderManager").GetComponent<OrderManager>();
        locked = true;
        holdingObject = false;
        carBlueprint.SetActive(false);
        eCarBlueprint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //end game conditions
        if (gM.gameWon || gM.gameLost)
        {
            gameOver = true;
            gameOvert.text = "Someone is knocking at the door";
        }
        
        //cursor locking
        if(locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        //crafting menu
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (crafting)
            {
                crafting = false;
                locked = true;
            }
            else
            {
                crafting = true;
                locked = false;
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
        if (gM.carUnlocked)
        {
            carBlueprint.SetActive(true);
        }

        if (gM.eCarUnlocked)
        {
            eCarBlueprint.SetActive(true);
        }
        
        //ui setting
        order = oM.ReturnOrderName();
        currentOrder.text = order;
        cashValue.text = gM.cash.ToString();
        
        //item ordering
        if (gM.itemOrdered)
        {
            SpawnPackage();
            gM.itemOrdered = false;
        }       
    }

    public void SpawnPackage()
    {
        _currentPackage = Instantiate(packageObject, packageSpawn.position, packageSpawn.rotation);
        pM = _currentPackage.GetComponent<PackageManager>();
        pM.itemsInPackage = gM.orderedItems;
    }

    public void OpenPackage(GameObject package)
    {
        pM = package.GetComponent<PackageManager>();
        for(int i = 0; i < pM.itemsInPackage.Count; i++)
        {
            spawnedObject = Instantiate(pM.itemsInPackage[i], package.transform.position, package.transform.rotation);
            spawnedObject.SetActive(true);
        }
        Destroy(package);
    }
}
