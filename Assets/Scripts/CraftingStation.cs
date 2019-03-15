using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public List<GameObject> itemsList = new List<GameObject>();

    public int cubes;
    public int tmpCubes;
    public int smallCubes;
    public int nails;
    public int gunPow;
    public int tmpSmallCubes;
    public int miniCubes;
    public int tmpMiniCubes;
    public int tmpNails;
    public int tmpGunPow;
    public int removeSmallCubes;
    public int removeCubes;
    public int removeMiniCubes;
    public int removeNails;
    public int removeGunPow;
    public int tmpRemoveSmallCubes;
    public int tmpRemoveCubes;
    public int tmpRemoveMiniCubes;
    public int tmpRemoveNails;
    public int tmpRemoveGunPow;

    public Transform spawn;

    public GameObject block;
    public GameObject lego;
    public GameObject car;
    public GameObject eCar;

    public AudioSource aS;
    public bool spawnToy;
    public bool crafting;

    public GameManager gM;
    public GameObject gameObjectToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        spawnToy = false;
        crafting = false;
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (crafting == false && spawnToy && !aS.isPlaying)
        {
            Instantiate(gameObjectToSpawn, spawn.position, spawn.rotation);
            spawnToy = false;
            gameObjectToSpawn = null;
        }

        for (int x = 0; x < itemsList.Count; x++)
        {
            
            if (itemsList[x] == null)
            {
                itemsList.Remove(itemsList[x]);
            }
            //print(itemsList[x].transform.tag);
            if (itemsList[x].transform.tag == "Cube")
            {
                tmpCubes += 1;
                //print("Cube in List");
            }
            if (itemsList[x].transform.tag == "SmallCube")
            {
                tmpSmallCubes += 1;
                //print("Cube in List");
            }
            if (itemsList[x].transform.tag == "MiniCube")
            {
                tmpMiniCubes += 1;
                //print("Cube in List");
            }
            if (itemsList[x].transform.tag == "Nails")
            {
                tmpNails += 1;
            }
            if (itemsList[x].transform.tag == "GunPow")
            {
                tmpGunPow += 1;
            }
        
        }

        if (tmpCubes != cubes)
        {
            cubes = tmpCubes;
        }
        if (tmpSmallCubes != smallCubes)
        {
            smallCubes = tmpSmallCubes;
        }
        if (tmpMiniCubes != miniCubes)
        {
            miniCubes = tmpMiniCubes;
        }
        if (tmpNails != nails)
        {
            nails = tmpNails;
        }
        if (tmpGunPow != gunPow)
        {
            gunPow = tmpGunPow;
        }
        tmpCubes = 0;
        tmpSmallCubes = 0;
        tmpMiniCubes = 0;
        tmpNails = 0;
        tmpGunPow = 0;
    }

    public void AddtoList(GameObject item)
    {
        itemsList.Add(item);
    }

    public void RemoveItem(GameObject item)
    {
        itemsList.Remove(item);
    }

    public void CraftBlock()
    {
        if (crafting == false)
        {
            crafting = true;
            gM.crafting = false;
            aS.Play();
            removeSmallCubes = 1;
            print("CraftBlock");
            if (smallCubes >= 1)
            {
                print("SmallCubes");
                for(int x = 0; x < itemsList.Count; x++)
                {
                    if (itemsList[x].transform.tag == "SmallCube")
                    {
                        Destroy(itemsList[x]);
                        tmpRemoveSmallCubes += 1;
                    }

                    if (tmpRemoveSmallCubes == removeSmallCubes)
                    {
                        tmpRemoveSmallCubes = 0;
                        removeSmallCubes = 0;
                        break;
                    }

                }

                gameObjectToSpawn = block;
                spawnToy = true;
                crafting = false;
            }
        } 
    }

    public void CraftLego()
    {
        if (crafting == false)
        {
            crafting = true;
            gM.crafting = false;
            aS.Play();
            removeSmallCubes = 1;
            removeMiniCubes = 6;
            if (smallCubes >= 1 && miniCubes >=6)
            {
                for (int x = 0; x < itemsList.Count; x++)
                {
                    if (itemsList[x].transform.tag == "SmallCube")
                    {
                        if (removeSmallCubes != 0)
                        {
                            Destroy(itemsList[x]);
                            tmpRemoveSmallCubes += 1; 
                        }
                    }

                    if (itemsList[x].transform.tag == "MiniCube")
                    {
                        if (removeMiniCubes != 0)
                        {
                            Destroy(itemsList[x]);
                            tmpRemoveMiniCubes += 1;
                        }
                    }

                    if (tmpRemoveSmallCubes == removeSmallCubes)
                    {
                        removeSmallCubes = 0;
                        tmpRemoveSmallCubes = 0;
                    }

                    if (tmpRemoveMiniCubes == removeMiniCubes)
                    {
                        removeMiniCubes = 0;
                        tmpRemoveMiniCubes = 0;
                    }

                    if (removeMiniCubes == 0 && removeSmallCubes == 0)
                    {
                        break;
                    }
                }
                gameObjectToSpawn = lego;
                spawnToy = true;
                crafting = false;
            }
        }
        
    }

    public void CraftCar()
    {
        if (crafting == false)
        {
            crafting = true;
            gM.crafting = false;
            aS.Play();
            removeSmallCubes = 1;
            removeMiniCubes = 4;
            removeNails = 1;
            if (smallCubes >= 1 && miniCubes >= 4 && nails >= 1)
            {
                for (int x = 0; x < itemsList.Count; x++)
                {
                    if (itemsList[x].transform.tag == "SmallCube")
                    {
                        if (removeSmallCubes != 0)
                        {
                            Destroy(itemsList[x]);
                            //itemsList[x].SetActive(false);
                            tmpRemoveSmallCubes += 1;
                        }
                    }

                    if (itemsList[x].transform.tag == "MiniCube")
                    {
                        if (removeMiniCubes != 0)
                        {
                            Destroy(itemsList[x]);
                            tmpRemoveMiniCubes += 1;
                        }
                    }
                    if (itemsList[x].transform.tag == "Nails")
                    {
                        if (removeNails != 0)
                        {
                            Destroy(itemsList[x]);
                            tmpRemoveNails += 1;
                        }
                    }

                    if (tmpRemoveSmallCubes == removeSmallCubes)
                    {
                        removeSmallCubes = 0;
                        tmpRemoveSmallCubes = 0;
                    }

                    if (tmpRemoveMiniCubes == removeMiniCubes)
                    {
                        removeMiniCubes = 0;
                        tmpRemoveMiniCubes = 0;
                    }
                    if (tmpRemoveNails == removeNails)
                    {
                        removeNails = 0;
                        tmpRemoveNails = 0;
                    }

                    if (removeMiniCubes == 0 && removeSmallCubes == 0 && removeNails == 0)
                    {
                        break;
                    }
                }
                gameObjectToSpawn = car;
                spawnToy = true;
                crafting = false;
            }
        }
    }

    public void CraftECar()
    {
        if (crafting == false)
        {
            crafting = true;
            gM.crafting = false;
            aS.Play();
        }
        removeSmallCubes = 1;
        removeMiniCubes = 4;
        removeNails = 1;
        removeGunPow = 1;
        if (smallCubes >= 1 && miniCubes >= 4 && nails >= 1 && gunPow >= 1)
        {
            for (int x = 0; x < itemsList.Count; x++)
            {
                if (itemsList[x].transform.tag == "SmallCube")
                {
                    if (removeSmallCubes != 0)
                    {
                        Destroy(itemsList[x]);
                        tmpRemoveSmallCubes += 1;
                    }
                }

                if (itemsList[x].transform.tag == "MiniCube")
                {
                    if (removeMiniCubes != 0)
                    {
                        Destroy(itemsList[x]);
                        tmpRemoveMiniCubes += 1;
                    }
                }
                if (itemsList[x].transform.tag == "Nails")
                {
                    if (removeNails != 0)
                    {
                        Destroy(itemsList[x]);
                        tmpRemoveNails += 1;
                    }
                }
                if (itemsList[x].transform.tag == "GunPow")
                {
                    if (removeGunPow != 0)
                    {
                        Destroy(itemsList[x]);
                        tmpRemoveGunPow += 1;
                    }
                }

                if (tmpRemoveSmallCubes == removeSmallCubes)
                {
                    removeSmallCubes = 0;
                    tmpRemoveSmallCubes = 0;
                }

                if (tmpRemoveMiniCubes == removeMiniCubes)
                {
                    removeMiniCubes = 0;
                    tmpRemoveMiniCubes = 0;
                }
                if (tmpRemoveNails == removeNails)
                {
                    removeNails = 0;
                    tmpRemoveNails = 0;
                }
                if (tmpRemoveGunPow == removeGunPow)
                {
                    removeGunPow = 0;
                    tmpRemoveGunPow = 0;
                }
                if (removeMiniCubes == 0 && removeSmallCubes == 0 && removeNails == 0 && removeGunPow == 0)
                {
                    break;
                }
            }
            gameObjectToSpawn = eCar;
            spawnToy = true;
            crafting = false;
        }
    }

    
}
