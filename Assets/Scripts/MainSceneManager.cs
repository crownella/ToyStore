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
    

    void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        oM = GameObject.FindWithTag("OrderManager").GetComponent<OrderManager>();
        locked = true;
        holdingObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
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
        for(int i = 0; i < pM.itemsInPackage.Count; i++)
        {
            print("i =" + i);
            print(pM.itemsInPackage[i].gameObject.name);
        }
        pM.itemsInPackage = gM.orderedItems;
        for(int i = 0; i < pM.itemsInPackage.Count; i++)
        {
            print("x =" + i);
            print(pM.itemsInPackage[i].gameObject.name);
        }
        gM.orderedItems.Clear();
    }

    public void OpenPackage(GameObject package)
    {
        print("OPenPackage");
        pM = package.GetComponent<PackageManager>();
        for(int i = 0; i < pM.itemsInPackage.Count; i++)
        {
            print(pM.itemsInPackage[i].gameObject.name);
            Instantiate(pM.itemsInPackage[i], package.transform.position, package.transform.rotation);
        }
        Destroy(package);
    }
}
