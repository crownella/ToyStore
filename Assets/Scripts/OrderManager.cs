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
    //public Text name;
    //public Text pay;
    //public Text customerName;
    //public Text shippingLocation;
    //public Text text;

    public bool gameFinished;

    public GameObject Lego;
    public GameObject Block;
    public GameObject Car;
    public GameObject ExplosiveCar;

    //public Text order1t;
    //public Text order2t;

    public Order clickedOrder;
    public Order Order1Spot;
    public Order Order2Spot;
    //public Text pending;
    
    private static OrderManager _instance;
    public static OrderManager Instance
    {
        get { return _instance; }
    }


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
    public List<Order> allOrders = new List<Order>();
    public List<Order> receivedOrders = new List<Order>();
    public List<Order> completedOrders = new List<Order>();
    public Order activeOrder;
    
    
    //make orders                                                           <<<<First add order here
    public List<GameObject> order1List = new List<GameObject>();
    public List<GameObject> order2List = new List<GameObject>();
    public List<GameObject> order3List = new List<GameObject>();
    public List<GameObject> order4List = new List<GameObject>();
    public List<GameObject> order5List = new List<GameObject>();
    public Order order1;                                                   //And here
    public Order order2;
    public Order order3;
    public Order order4;
    public Order order5;
    
    void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        
        //make orders                                                                  <<<<Then add order here
        order1 = new Order(("Amy Lone"), ("Dallas"),("Please send me 3 blocks for my sister's baby shower present."),("3 Blocks"), ("15$"),15, 1);
        order2 = new Order(("Jimmy Yon"), ("Oldtown"),("My Cat likes Legos, please send 2."),("2 Legos"), ("10$"),10, 2);
        order3 = new Order(("John Gimme"), ("Charles"),("Can you send a car for my sons birthday? He turns 1 in four days."),("1 Car"), ("14$"),14, 3);
        order4 = new Order(("Anonymous"), ("Nowhere"),("I need one Explosive Car. By tomorrow."),("1 Explosive Car"), ("100$"),100, 4);
        order5 = new Order(("Anonymous"), ("Capital"),("Ive heard you make great toys. I need 5 Blocks, 3 Legos, and 2 Cars of the highest quality."),("5 Blocks 3 Legos 2 Cars"), ("200$"),200, 5);
        
        
        //make master order list                                                       <<<<Then add order here
        allOrders.Add(order1);
        allOrders.Add(order2);
        allOrders.Add(order3);
        allOrders.Add(order4);
        allOrders.Add(order5);
        
        //make lists for every order                                                   <<<<Then add  order here
        order1List.Add(Block);
        order1List.Add(Block);
        order1List.Add(Block);
        
        order2List.Add(Lego);
        order2List.Add(Lego);
        
        order3List.Add(Car);
        
        order4List.Add(ExplosiveCar);
        
        order5List.Add(Block);
        order5List.Add(Block);
        order5List.Add(Block);
        order5List.Add(Block);
        order5List.Add(Block);
        order5List.Add(Lego);
        order5List.Add(Lego);
        order5List.Add(Lego);
        order5List.Add(Car);
        order5List.Add(Car);

        currentOrderNumber = 1;
        gameFinished = false;
        clickedOrder = order1;
        receivedOrders.Add(order1);
        receivedOrders.Add(order2);
        //pending.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        //print("copleted orders" +completedOrders.Count);
        //print("recieved orders" +receivedOrders.Count);
 
        if (gM.computer)
        {
            Order1Spot = receivedOrders[0];
            //order1t.text = Order1Spot.CustomerName;
            if (receivedOrders.Count > 1)
            {
                Order2Spot = receivedOrders[1];
                //order2t.text = Order2Spot.CustomerName;
            }
            else
            {
                //order2t.text = "";
            }
            
           // name.text = clickedOrder.CustomerName;
            //pay.text = clickedOrder.OrderPay;
            //shippingLocation.text = clickedOrder.ShippingLocation;
            //text.text = clickedOrder.OrderText;
        }

        if (orderCompleted == true)
        {
            completedOrders.Add(activeOrder);
            receivedOrders.Remove(activeOrder);
            orderCompleted = false;
            orderActive = false; 
        }

        if (completedOrders.Count > 0 && completedOrders.Contains(order3) == false && receivedOrders.Contains(order3) == false)      //<<<<Then add order here 
        {
            //print("addorder3");
            receivedOrders.Add(order3);
        }

        if (completedOrders.Count > 1 && completedOrders.Contains(order4) == false && receivedOrders.Contains(order4) == false)
        {
            //print("addorder4");
            receivedOrders.Add(order4);
        }

        if (completedOrders.Count > 2 && receivedOrders.Contains(order5) == false)
        {
            receivedOrders.Add(order5);
        }
  
    }

    public List<GameObject> GetOrderList(int oN)                                                                                 //<<<<Last add order here
    {
        if (oN == 1)
        {
            return order1List;
        }else if (oN == 2)
        {
            return order2List;
        }else if(oN == 3)
        {
            return order3List;
        }else if(oN == 4)
        {
            return order4List;
        }else if(oN == 5)
        {
            return order5List;
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

    public void SelectOrder1(Text pending)
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
    
    public void SelectOrder2(Text pending)
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

    public void SelectOrder(Text pending)
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

    public void ResetPending(Text pending)
    {
        if (activeOrder != clickedOrder)
        {
            pending.text = ("");
        }
    }
    
}
