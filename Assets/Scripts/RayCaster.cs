using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCaster : MonoBehaviour
{
    public float rayDis = 2f;
    public float mouseRayDis = 40f;
    public Transform placeHolder;
    public float placementMod = .1f;
    public Transform objectPosition;
    public GameManager gM;
    public PickUpScript pUS;
    public Cutter Cutter;
    public GameObject emptyPackage;
    public GameObject closedPackage;
    public Transform packageSpawn;
    public PackageManager pM;
    public inPackageManager iPM;

    public MainSceneManager mM;
    
    

    public Vector3 endOfRay;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Ray myRay = new Ray(this.transform.position, Vector3.down);
        
        Debug.DrawRay(myRay.origin, new Vector3(0 ,-rayDis,0));

        RaycastHit myHit;

        if (Physics.Raycast(myRay.origin, myRay.direction, out myHit, rayDis))
        {
            print(myHit.rigidbody.transform.name);
        }
        

        Ray ObjectRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //Debug.DrawRay(ObjectRay.origin, ObjectRay.direction * rayDis);
        
        //endOfRay = new Vector3(mouseRay.direction.x, mouseRay.direction.y, mouseRay.direction.z);

        RaycastHit objectHit;

        if (Physics.Raycast(ObjectRay.origin, ObjectRay.direction, out objectHit, rayDis))
        {

            if (objectHit.transform.tag == "Surface")
            {
                placeHolder.transform.position = new Vector3(objectHit.point.x,objectHit.point.y + placementMod,objectHit.point.z);
                
            }else if(objectHit.transform.tag == "WallNorth")
            {
                placeHolder.transform.position = new Vector3(objectHit.point.x + placementMod,objectHit.point.y,objectHit.point.z);
            }
            else if(objectHit.transform.tag == "WallSouth")
            {
                placeHolder.transform.position = new Vector3(objectHit.point.x - placementMod,objectHit.point.y,objectHit.point.z);
            }else if(objectHit.transform.tag == "WallWest")
            {
                placeHolder.transform.position = new Vector3(objectHit.point.x,objectHit.point.y,objectHit.point.z + placementMod);
            }else if(objectHit.transform.tag == "WallEast")
            {
                placeHolder.transform.position = new Vector3(objectHit.point.x,objectHit.point.y,objectHit.point.z - placementMod);
            }
        }
        else
        {
            placeHolder.transform.position = objectPosition.position;
        }

        if (Input.GetMouseButton(0))
        {
            //Transform newCube = Instantiate(cube, cube.transform.position, Quaternion.Euler(0,0,0)); //spawns cube when u click moue at where ever the cube is
        }
        */
        
        //Ray MouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray MouseRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward * mouseRayDis);
        
        Debug.DrawRay(MouseRay.origin, MouseRay.direction * mouseRayDis);

        RaycastHit mouseHit;
        
        if (Physics.Raycast(MouseRay.origin, MouseRay.direction, out mouseHit, mouseRayDis))
        {
            if (mM.crafting == false)
            {
                  if (mouseHit.transform.tag == "Cube" || mouseHit.transform.tag == "MiniCube" || mouseHit.transform.tag == "SmallCube" || mouseHit.transform.tag == "Lego" || mouseHit.transform.tag == "Block")
               {
                   pUS = mouseHit.transform.GetComponent<PickUpScript>();
                   if (pUS.holding == false)
                   {
                       mM.message.text = ("Click To Pick Up");
                   }
                   else
                   {
                       mM.message.text = ("Click To Drop");
                   }
                
                   if (Input.GetMouseButtonDown(0))
                   {
                    
                       if (pUS.holding == false)
                       {
                           pUS.holding = true;
                       }
                       else
                       {
                           pUS.holding = false;
                       }
                   
                   }
               }else if(mouseHit.transform.tag == "SawButtonOff")
               {
                   mM.message.text = ("Click To Turn On");
                   if (Input.GetMouseButtonDown(0))
                   {
                       Cutter.TurnOnSaw();
                   } 
               }else if(mouseHit.transform.tag == "SawButtonOn")
               {
                   mM.message.text = ("Click To Turn Off");
                   if (Input.GetMouseButtonDown(0))
                   {
                       Cutter.TurnOffSaw();
                   } 
                
               }else if(mouseHit.transform.tag == "Package")
               {
                   pUS = mouseHit.transform.GetComponent<PickUpScript>();
                   if (pUS.holding == false)
                   {
                       mM.message.text = ("Click To Pick Up, Press E to Open");
                   }
                   else
                   {
                       mM.message.text = ("Click To Drop");
                   }
                
                   if (Input.GetMouseButtonDown(0))
                   {
                    
                       if (pUS.holding == false)
                       {
                           pUS.holding = true;
                       }
                       else
                       {
                           pUS.holding = false;
                       }
                   
                   }
                   if (Input.GetKeyDown(KeyCode.E))
                   {
                       //gM.OpenPackage(mouseHit.transform.gameObject);
                   } 
                
               }else if(mouseHit.transform.tag == "EmptyPackage")
               {
                   iPM = mouseHit.transform.GetComponent<inPackageManager>();
                   pUS = mouseHit.transform.GetComponent<PickUpScript>();
                   if (pUS.holding == false)
                   {
                       mM.message.text = ("Click To Pick Up, Press E to Close");
                   }
                   else
                   {
                       mM.message.text = ("Click To Drop");
                   }
                
                   if (Input.GetMouseButtonDown(0))
                   {
                       
                       if (pUS.holding == false)
                       {
                           pUS.holding = true;
                       }
                       else
                       {
                           pUS.holding = false;
                       }
                   
                   }
                   if (Input.GetKeyDown(KeyCode.E))
                   {
                       pM = Instantiate(closedPackage, mouseHit.transform.position, mouseHit.transform.rotation).GetComponent<PackageManager>();
                       pM.GetContents(iPM);
                       for(int i = 0; i < iPM.inPackage.Count; i++)
                       {
                           iPM.inPackage[i].gameObject.SetActive(false);
                       }
                       Destroy(mouseHit.transform.gameObject);
                   } 
               }else if(mouseHit.transform.tag == "BoxStack")
               {
                   mM.message.text = ("Click To Pick Up");

                   if (Input.GetMouseButtonDown(0))
                   {

                       pUS = Instantiate(emptyPackage, packageSpawn.position, packageSpawn.rotation).GetComponent<PickUpScript>();
                   } 
               }else if(mouseHit.transform.tag == "Computer")
                  {
                      mM.message.text = ("Click To Turn On");

                      if (Input.GetMouseButtonDown(0))
                      {
                          gM.computer = true;
                          SceneManager.LoadScene("Computer");
                      } 
                  }else
               {
                   mM.message.text = ("");
               } 
            } 
        }
        else
        {
            mM.message.text = ("");
        }
    }
}
