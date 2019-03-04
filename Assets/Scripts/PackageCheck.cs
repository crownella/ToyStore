using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackageCheck : MonoBehaviour
{
    public PackageManager pM;
    public OrderManager oM;

    public List<GameObject> packageList = new List<GameObject>();
    public List<GameObject> orderList = new List<GameObject>();

    public Text packageNoti;
    public Transform delSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
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
        packageList = pM.itemsInPackage;
        //orderList = oM.GetOrderList(oM.activeOrder.OrderNumber);
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
            packageNoti.text = "Package Accepted";
            oM.orderCompleted = true;
            Destroy(package);
            for(int i = 0; i < packageList.Count; i++)
            {
                Destroy(packageList[i].gameObject);
            }
        }
        else
        {
            packageNoti.text = "Package Denied";
            Instantiate(package, delSpawn.position, delSpawn.rotation);
        }
    }
}
