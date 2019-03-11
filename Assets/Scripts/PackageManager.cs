using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public List<GameObject> itemsInPackage = new List<GameObject>();
    public GameManager gM;
    
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = 0; i < itemsInPackage.Count; i++)
            {
                print(itemsInPackage[i].tag);
            }
        }
    }

    public void GetContents(inPackageManager iPM)
    {
        itemsInPackage = iPM.GetItems();
    }

 
}
