using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public int orderNumber;
    public bool orderActive;
    public bool orderCompleted;
    public int ordersCompleted;
    public Text name;
    public Text pay;
    public Text customerName;
    public Text shippingLocation;
    public Text text;
    public class Order
    {
        
        public string CustomerName;
        public string ShippingLocation;
        public string OrderText; 
        public string OrderName;
        public string OrderPay;

        public Order(string cN, string sl, string oT, string oN, string oP)
        {
            cN = CustomerName;
            sl = ShippingLocation;
            oT = OrderText;
            oN = OrderName;
            oP = OrderPay;
        }
    }
    List<Order> allOrders = new List<Order>();
    List<Order> activeOrders = new List<Order>();
    List<Order> completedOrders = new List<Order>();
    public Order activeOrder;
    
    
    //make orders
    
    public Order order1 = new Order(("Amy Lone"), ("Dallas"),("Please send me 3 blocks for my sister's baby shower present."),("3 Blocks"), ("6$"));
    public Order order2 = new Order(("Jimmy Yon"), ("Oldtown"),("My Cat likes Legos, please send 2."),("2 Legos"), ("4$"));
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        allOrders.Add(order1);
        allOrders.Add(order2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
