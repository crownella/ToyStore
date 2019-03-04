using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inPackageManager : MonoBehaviour
{
    public List<GameObject> inPackage = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < inPackage.Count; i++)
            {
                print(inPackage[i].tag);
            }
        }
        
    }

    public void addItem(GameObject gameObject)
    {
        inPackage.Add(gameObject);
    }

    public void removeItem(GameObject gameObject)
    {
        inPackage.Remove(gameObject);
    }

    public List<GameObject> GetItems()
    {
        return inPackage;
    }

   
}
