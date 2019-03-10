using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    public GameManager gM;

    public bool browser = false;
    
    public bool craftStore = true;
    public bool orders = false;
    public bool shopUpgrades = false;

    public bool cubes = true;
    public bool nails = false;
    public bool gunPow = false;

    public bool nailsUnlocked = false;
    public bool gunPowUnlocked = false;

    public Text itemDescript;
    public Button nailsButton;
    public Button gunPowButton;

    public Image cubesPic;
    public Image nailsPic;
    public Image gunPowPic;

    public GameObject browserPanel;
    public GameObject craftPanel;
    public GameObject orderPanel;
    public GameObject shopUpgradePanel;
    
    public Text cashValue;
    
    
    // Start is called before the first frame update
    void Start()
    {
        nailsButton.gameObject.SetActive(false);
        gunPowButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (browser == false)
        {
            browserPanel.SetActive(false);
        }
        else
        {
            browserPanel.SetActive(true);
        }
        if (craftStore == true)
        {
            craftPanel.SetActive(true);
            orderPanel.SetActive(false);
            shopUpgradePanel.SetActive(false);

            if (cubes == true)
            {
                cubesPic.gameObject.SetActive(true);
                nailsPic.gameObject.SetActive(false);
                gunPowPic.gameObject.SetActive(false);

                itemDescript.text = ("3 large cubes of wood. Very Cubey.");
            }else if (nails == true)
            {
                cubesPic.gameObject.SetActive(false);
                nailsPic.gameObject.SetActive(true);
                gunPowPic.gameObject.SetActive(false);

                itemDescript.text = ("Box of Nails. Very Sharp. CraftStore.com is not liable for any accidents.");
            }else if (gunPow == true)
            {
                cubesPic.gameObject.SetActive(false);
                nailsPic.gameObject.SetActive(false);
                gunPowPic.gameObject.SetActive(true);

                itemDescript.text = ("Gun Powder. Be careful. CraftStore.com is not liable for any accidents.");
            }
        }else if(orders == true)
        {
            craftPanel.SetActive(false);
            orderPanel.SetActive(true);
            shopUpgradePanel.SetActive(false);
        }else if(shopUpgrades == true)
        {
            craftPanel.SetActive(false);
            orderPanel.SetActive(false);
            shopUpgradePanel.SetActive(true);
        }

        if (nailsUnlocked == true)
        {
            nailsButton.gameObject.SetActive(true);
        }

        if (gunPowUnlocked == true)
        {
            gunPowButton.gameObject.SetActive(true);
        }
        
        cashValue.text = gM.cash.ToString();

    }

    public void TurnOffComputer()
    {
        gM.LoadMainScene();
    }

    public void OpenCraftStore()
    {
        craftStore = true;
        orders = false;
        shopUpgrades = false;
    }

    public void OpenOrders()
    {
        orders = true;
        craftStore = false;
        shopUpgrades = false;
    }

    public void OpenShopUpgrades()
    {
        shopUpgrades = true;
        craftStore = false;
        orders = false;
    }

    public void SelectCubes()
    {
        cubes = true;
        nails = false;
        gunPow = false;
        
    }

    public void SelectNails()
    {
        cubes = false;
        nails = true;
        gunPow = false;
    }

    public void SelectGunPow()
    {
        cubes = false;
        nails = false;
        gunPow = true;
    }

    public void TurnOnBrowser()
    {
        browser = true;
    }

    public void TurnOffBrowser()
    {
        browser = false;
    }

    public void OrderItems()
    {
        if (gM.itemOrdered == false)
        {
            if (cubes == true)
            {
                gM.orderedItems.Add(gM.cube);   
                gM.orderedItems.Add(gM.cube);  
                gM.orderedItems.Add(gM.cube);
                gM.itemOrdered = true;
            }
        } 
    }
}
