using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageCheck : MonoBehaviour
{
    public PackageManager pM;
    public OrderManager oM;
    public GameManager gM;

    public List<GameObject> packageList = new List<GameObject>();
    public List<GameObject> orderList = new List<GameObject>();

    
    public Transform delSpawn;

    public AudioSource aS;

    public AudioClip accepted;

    public AudioClip denied;
    // Start is called before the first frame update
    void Start()
    {
        oM = GameObject.FindWithTag("OrderManager").GetComponent<OrderManager>();
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        pM = other.transform.GetComponent<PackageManager>();
        CheckPackage(other.gameObject);
    }

    public void CheckPackage(GameObject package)
    {
        if (oM.orderActive == false)
        {
            gM.packageNoti.text = "No Active Order";
            aS.clip = denied;
            aS.Play();
            Instantiate(package, delSpawn.position, delSpawn.rotation);
        }
        else
        {
            packageList = pM.itemsInPackage;
            orderList = oM.GetOrderList(oM.activeOrder.OrderNumber);
            for (int i = 0; i <packageList.Count; i++)
            {
                for (int x = 0; x <orderList.Count; x++)
                {
                    if (packageList[i].transform.tag == orderList[x].transform.tag)
                    {
                        orderList.Remove(orderList[x]);
                    }
            
                }

                if (orderList.Count == 0)
                {
                    break;
                }
            }
            if (orderList.Count == 0)
            {
                gM.packageNoti.text = "Package Accepted";
                aS.clip = accepted;
                aS.Play();
                gM.cash += oM.activeOrder.OrderPayInt;
                oM.orderCompleted = true;
                Destroy(package);
                for(int i = 0; i < packageList.Count; i++)
                {
                    Destroy(packageList[i].gameObject);
                }
            }
            else
            {
                aS.clip = denied;
                aS.Play();
                gM.packageNoti.text = "Package Denied";
                Instantiate(package, delSpawn.position, delSpawn.rotation);
            }
        }
        
    }
}
