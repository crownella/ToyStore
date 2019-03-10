using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public GameManager gM;
    
    public int currentOrderNumber;
    public bool orderActive;
    public bool orderCompleted;
    public int ordersCompleted;
    public Text name;
    public Text pay;
    //public Text customerName;
    public Text shippingLocation;
    public Text text;

    public bool gameFinished;

    public GameObject Lego;
    public GameObject Block;
    public GameObject Car;
    public GameObject ExplosiveCar;

    public Text order1t;
    public Text order2t;

    public Order clickedOrder;
    public Order Order1Spot;
    public Order Order2Spot;
    public Text pending;
    
    


    public class Order
    {
        
        public string CustomerName;
        public string ShippingLocation;
        public string OrderText; 
        public string OrderName;
        public string OrderPay;
        public int OrderNumber;
        public int OrderPayInt;

        public Order(string cN, string sl, string oT, string oN, string oP,int oPI, int oNN)
        {
            CustomerName = cN;
            ShippingLocation = sl;
            OrderText = oT;
            OrderName = oN;
            OrderPay = oP;
            OrderPayInt = oPI;
            OrderNumber = oNN;

        }
    }
    List<Order> allOrders = new List<Order>();
    List<Order> receivedOrders = new List<Order>();
    List<Order> completedOrders = new List<Order>();
    public Order activeOrder;
    
    
    //make orders
    public List<GameObject> order1List = new List<GameObject>();
    public List<GameObject> order2List = new List<GameObject>();
    public List<GameObject> order3List = new List<GameObject>();
    public List<GameObject> order4List = new List<GameObject>();
    public Order order1;
    public Order order2;
    public Order order3;
    public Order order4;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
        //make orders
        order1 = new Order(("Amy Lone"), ("Dallas"),("Please send me 3 blocks for my sister's baby shower present."),("3 Blocks"), ("15$"),15, 1);
        order2 = new Order(("Jimmy Yon"), ("Oldtown"),("My Cat likes Legos, please send 2."),("2 Legos"), ("10$"),10, 2);
        order3 = new Order(("John Gimme"), ("Charles"),("Can you send a car for my sons birthday? He turns 1 in four days."),("1 Car"), ("14$"),14, 3);
        order4 = new Order(("Amanda Yukon"), ("Valley"),("I need one Explosive Car. By tomorrow."),("1 Explosive Carr"), ("100$"),100, 4);
        
        
        //make master order list
        allOrders.Add(order1);
        allOrders.Add(order2);
        allOrders.Add(order3);
        allOrders.Add(order4);
        
        //make lists for every order
        order1List.Add(Block);
        order1List.Add(Block);
        order1List.Add(Block);
        
        order2List.Add(Lego);
        order2List.Add(Lego);
        
        order3List.Add(Car);
        
        order4List.Add(ExplosiveCar);

        currentOrderNumber = 1;
        gameFinished = false;
        clickedOrder = order1;
        receivedOrders.Add(order1);
        receivedOrders.Add(order2);
        //activeOrder.Equals(order1);

    }

    // Update is called once per frame
    void Update()
    {
        if (gM.computer)
        {
            Order1Spot = receivedOrders[0];
            order1t.text = Order1Spot.CustomerName;
            if (receivedOrders.Count > 1)
            {
                Order2Spot = receivedOrders[1];
                order2t.text = Order2Spot.CustomerName;
            }
            else
            {
                order2t.text = "";
            }
            
            name.text = clickedOrder.CustomerName;
            pay.text = clickedOrder.OrderPay;
            shippingLocation.text = clickedOrder.ShippingLocation;
            text.text = clickedOrder.OrderText;
        }

        if (orderCompleted == true)
        {
            completedOrders.Add(activeOrder);
            receivedOrders.Remove(activeOrder);
            orderCompleted = false;
            orderActive = false; 
        }
  
    }

    public List<GameObject> GetOrderList(int oN)
    {
        if (oN == 1)
        {
            return order1List;
        }else if (oN == 2)
        {
            return order2List;
        }else
        {
            return null;
        }
    }

    public string ReturnOrderName()
    {
        if (gameFinished)
        {
            return "You Won";
        }
        else if(orderActive == true)
        {
            
            return activeOrder.OrderName;
        }
        else
        {
            return ("No active order");
        }
    }

    public void SelectOrder1()
    {
        clickedOrder = Order1Spot;
        if (activeOrder != clickedOrder)
        {
            pending.text = ("");
        }
        else
        {
            pending.text = ("Pending");
        }
    }
    
    public void SelectOrder2()
    {
        clickedOrder = Order2Spot;
        if (activeOrder != clickedOrder)
        {
            pending.text = ("");
        }
        else
        {
            pending.text = ("Pending");
        }
    }

    public void SelectOrder()
    {
        if (orderActive == false)
        {
            activeOrder = clickedOrder;
            orderActive = true;
            pending.text = ("Pending");
            currentOrderNumber = activeOrder.OrderNumber;
        }
        else if (activeOrder == clickedOrder)
        {
            pending.text = ("Error: Order Already Active");
        }
        else
        {
            pending.text = ("Another Order Active");
        }
    }
    
}
