﻿using System.Collections;
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
    // Start is called before the first frame update
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
    }
}
