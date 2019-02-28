using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    List<GameObject> itemsList = new List<GameObject>();

    public int cubes;
    public int tmpCubes;
    public int smallCubes;
    public int tmpSmallCubes;
    public int miniCubes;
    public int tmpMiniCubes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < itemsList.Count; x++)
        {
            //print(itemsList[x].transform.tag);
            if (itemsList[x].transform.tag == "Cube")
            {
                tmpCubes += 1;
                //print("Cube in List");
            }
        }

        if (tmpCubes < cubes)
        {
            cubes = tmpCubes;
        }
    }

    public void AddtoList(GameObject item)
    {
        itemsList.Add(item);
    }

    public void RemoveItem(GameObject item)
    {
        itemsList.Remove(item);
    }
}
