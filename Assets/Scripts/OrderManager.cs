using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public int currentOrderNumber;
    public bool orderActive;
    public bool orderCompleted;
    public int ordersCompleted;
    public Text name;
    public Text pay;
    public Text customerName;
    public Text shippingLocation;
    public Text text;
    public bool gameFinished;

    public GameObject Lego;
    public GameObject Block;
    public class Order
    {
        
        public string CustomerName;
        public string ShippingLocation;
        public string OrderText; 
        public string OrderName;
        public string OrderPay;
        public int OrderNumber;

        public Order(string cN, string sl, string oT, string oN, string oP, int oNN)
        {
            CustomerName = cN;
            ShippingLocation = sl;
            OrderText = oT;
            OrderName = oN;
            OrderPay = oP;
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
    public Order order1;
    public Order order2;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
        //make orders
        order1 = new Order(("Amy Lone"), ("Dallas"),("Please send me 3 blocks for my sister's baby shower present."),("3 Blocks"), ("6$"), 1);
        order2 = new Order(("Jimmy Yon"), ("Oldtown"),("My Cat likes Legos, please send 2."),("2 Legos"), ("4$"), 2);
        
        
        //make master order list
        allOrders.Add(order1);
        allOrders.Add(order2);
        
        //make lists for every order
        order1List.Add(Block);
        order1List.Add(Block);
        order1List.Add(Block);
        
        order2List.Add(Lego);
        order2List.Add(Lego);

        currentOrderNumber = 1;
        gameFinished = false;
        //activeOrder.Equals(order1);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentOrderNumber == 1)
        {
            activeOrder = order1;
        }else if (currentOrderNumber == 2)
        {
            activeOrder = order2;
        }else if (currentOrderNumber > 2)
        {
            gameFinished = true;
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
        else
        {
            return activeOrder.OrderName;
        }
    }
}
