using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    public GameManager gM;
    public OrderManager oM;

    public bool browser = false;
    
    public bool craftStore = true;
    public bool orders = false;
    public bool shopUpgrades = false;
    
    public GameObject browserPanel;
    public GameObject craftPanel;
    public GameObject orderPanel;
    public GameObject shopUpgradePanel;

    //craft store
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

    public bool cubesOrdered = false;
    public bool nailsOrdered = false;
    public bool gunPowOrdered = false;
    
    public Text cashValue;
    public Text itemOrdered;
    public Text price;

    public int cubesPrice = 5;
    public int nailsPrice = 7;
    public int gunPowPrice = 15;
    
    //shop upgrades

    public bool carBlue = true;
    public bool eCarBlue = false;

    public Image careBlueprintPic;
    public Image eCarBlueprintPic;

    public int carBluePrice = 2;
    public int eCarBluePrice = 4;

    public Text blueprintPrice;
    public Text bought;
    public Text blueprintName;
    
    //order manager move
    public Text name;
    public Text pay;
    //public Text customerName;
    public Text shippingLocation;
    public Text text;
    
    public Text order1t;
    public Text order2t;
    public Text pending;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        oM = GameObject.FindWithTag("OrderManager").GetComponent<OrderManager>();
        nailsButton.gameObject.SetActive(false);
        gunPowButton.gameObject.SetActive(false);
        pending.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //end game conditons
        if (oM.completedOrders.Contains(oM.order4))
        {
            gM.gameLost = true;
            gM.gameWon = false;
        }else if (oM.completedOrders.Contains(oM.order5))
        {
            gM.gameWon = true;
            gM.gameLost = false;
        }
        
        //computer management
        if (browser == false)
        {
            browserPanel.SetActive(false);
        }
        else
        {
            browserPanel.SetActive(true);
        }
        if (craftStore)
        {
            craftPanel.SetActive(true);
            orderPanel.SetActive(false);
            shopUpgradePanel.SetActive(false);

            if (cubes)
            {
                cubesPic.gameObject.SetActive(true);
                nailsPic.gameObject.SetActive(false);
                gunPowPic.gameObject.SetActive(false);

                price.text = cubesPrice.ToString();

                if (cubesOrdered)
                {
                    itemOrdered.text = ("On The Way");
                }
                else if(nailsOrdered|| gunPowOrdered)
                {
                    itemOrdered.text = ("CraftStore.com can only fulfill one order at a time, dont be greedy.");
                }
                else
                {
                    itemOrdered.text = ("");
                }

                itemDescript.text = ("3 large cubes of wood. Very Cubey.");
            }else if (nails)
            {
                cubesPic.gameObject.SetActive(false);
                nailsPic.gameObject.SetActive(true);
                gunPowPic.gameObject.SetActive(false);

                price.text = nailsPrice.ToString();
                
                if (nailsOrdered)
                {
                    itemOrdered.text = ("On The Way");
                }
                else if(cubesOrdered|| gunPowOrdered)
                {
                    itemOrdered.text = ("CraftStore.com can only fulfill one order at a time, dont be greedy.");
                }
                else
                {
                    itemOrdered.text = ("");
                }

                itemDescript.text = ("Box of Nails. Very Sharp. CraftStore.com is not liable for any accidents.");
            }else if (gunPow)
            {
                cubesPic.gameObject.SetActive(false);
                nailsPic.gameObject.SetActive(false);
                gunPowPic.gameObject.SetActive(true);

                price.text = gunPowPrice.ToString();
                
                if (gunPowOrdered)
                {
                    itemOrdered.text = ("On The Way");
                }
                else if(nailsOrdered|| cubesOrdered)
                {
                    itemOrdered.text = ("CraftStore.com can only fulfill one order at a time, dont be greedy.");
                }
                else
                {
                    itemOrdered.text = ("");
                }

                itemDescript.text = ("Gun Powder. Be careful. CraftStore.com is not liable for any accidents.");
            }
        }else if(orders)
        {
            craftPanel.SetActive(false);
            orderPanel.SetActive(true);
            shopUpgradePanel.SetActive(false);

            order1t.text = oM.Order1Spot.CustomerName;
            if (oM.receivedOrders.Count > 1)
            {
                order2t.text = oM.Order2Spot.CustomerName;
            }
            else
            {
                order2t.text = "";
            }

            name.text = oM.clickedOrder.CustomerName;
            pay.text = oM.clickedOrder.OrderPay;
            shippingLocation.text = oM.clickedOrder.ShippingLocation;
            text.text = oM.clickedOrder.OrderText;
        }else if(shopUpgrades)
        {
            craftPanel.SetActive(false);
            orderPanel.SetActive(false);
            shopUpgradePanel.SetActive(true);

            if (carBlue)
            {
                careBlueprintPic.gameObject.SetActive(true);
                eCarBlueprintPic.gameObject.SetActive(false);
                blueprintPrice.text = carBluePrice.ToString();
                blueprintName.text = "Car Blueprint";
                if (gM.carUnlocked)
                {
                    bought.text = "Already Owned";
                }else
                {
                    bought.text = "";
                }
            }else if (eCarBlue)
            {
                eCarBlueprintPic.gameObject.SetActive(true);
                careBlueprintPic.gameObject.SetActive(false);
                blueprintPrice.text = eCarBluePrice.ToString();
                blueprintName.text = "Explosive Car Blueprint";
                if (gM.eCarUnlocked)
                {
                    bought.text = "Already Owned";
                }else
                {
                    bought.text = "";
                }
            }
        }

        if (nailsUnlocked)
        {
            nailsButton.gameObject.SetActive(true);
        }

        if (gunPowUnlocked)
        {
            gunPowButton.gameObject.SetActive(true);
        }
        
        cashValue.text = gM.cash.ToString();

        if (gM.itemOrdered == false)
        {
            cubesOrdered = false;
            nailsOrdered = false;
            gunPowOrdered = false;
        }

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

    public void SelectCar()
    {
        carBlue = true;
        eCarBlue = false;
    }

    public void SelectECar()
    {
        eCarBlue = true;
        carBlue = false;
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
            if (cubes)
            {
                if (gM.cash >= cubesPrice)
                {
                    gM.cash -= cubesPrice;
                    gM.orderedItems.Add(gM.cube);   
                    gM.orderedItems.Add(gM.cube);  
                    gM.orderedItems.Add(gM.cube);
                    gM.itemOrdered = true;
                    cubesOrdered = true;
                }
            }else if (nails)
            {
                if (gM.cash >= nailsPrice)
                {
                    gM.cash -= nailsPrice;
                    gM.orderedItems.Add(gM.nails);
                    gM.itemOrdered = true;
                    nailsOrdered = true;
                }
            }else if (gunPow)
            {
                if (gM.cash >= gunPowPrice)
                {
                    gM.cash -= gunPowPrice;
                    gM.orderedItems.Add(gM.gunPOw);
                    gM.itemOrdered = true;
                    gunPowOrdered = true;
                }
            }
        } 
    }

    public void UnlockBlueprint()
    {
        print("clicked");
        if (eCarBlue)
        {
            if (gM.eCarUnlocked == false && gM.cash > eCarBluePrice)
            {
                gM.cash -= eCarBluePrice;
                gM.eCarUnlocked = true;
            }
        }else if (carBlue)
        {
            if (gM.carUnlocked == false && gM.cash > carBluePrice)
            {
                gM.cash -= carBluePrice;
                gM.carUnlocked = true;
            }
        }
    }

    public void SelectOrder1()
    {
        oM.SelectOrder1(pending);
    }

    public void SelectOrder2()
    {
        oM.SelectOrder2(pending);
    }

    public void SelectOrder()
    {
        oM.SelectOrder(pending);
    }
}
