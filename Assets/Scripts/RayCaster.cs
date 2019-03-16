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

    public ObjectManager oM;
    public GameObject objectCasted;

    public AudioSource packageAudioSource;
    public AudioClip packageA;

    public AudioSource DoorAudio;
    public AudioClip open;

    public bool loadEnd = false;
   

    //public MainSceneManager mM;
    
    

    public Vector3 endOfRay;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DoorAudio.isPlaying && loadEnd)
        {
            gM.locked = false;
            if (gM.gameWon)
            {
                SceneManager.LoadScene("Win");
            }else if (gM.gameLost)
            {
                SceneManager.LoadScene("Lose");
            }
        }
        Ray MouseRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward * mouseRayDis);
        
        Debug.DrawRay(MouseRay.origin, MouseRay.direction * mouseRayDis);

        RaycastHit mouseHit;
        
        if (Physics.Raycast(MouseRay.origin, MouseRay.direction, out mouseHit, mouseRayDis))
        {
            if (gM.crafting == false && gM.computer == false)
            {
                if (gM.holdingObject)
                {
                    gM.message.text = ("Click To Drop");

                    if (Input.GetMouseButtonDown(0))
                    {
                        pUS.DropObject(gM.objectBeingHeld);
                    }

                    if (mouseHit.transform.tag == "Package")
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            gM.OpenPackage(mouseHit.transform.gameObject);
                            pUS.DropObject(gM.objectBeingHeld);
                        } 
                        
                    }
                }
                else
                {
                    if (mouseHit.transform.tag == "Cube" || mouseHit.transform.tag == "MiniCube" || mouseHit.transform.tag == "SmallCube" || mouseHit.transform.tag == "Lego" || mouseHit.transform.tag == "Block" || mouseHit.transform.tag == "GunPow" || mouseHit.transform.tag == "Nails" || mouseHit.transform.tag == "Car" || mouseHit.transform.tag == "ECar" )
                  {
                      oM = mouseHit.transform.GetComponent<ObjectManager>();
                      gM.message.text = ("Click To Pick Up");
                      if (Input.GetMouseButtonDown(0))
                      { 
                          pUS.PickUp(mouseHit.transform.gameObject);
                      }
                  }else if(mouseHit.transform.tag == "SawButtonOff")
                  {
                      gM.message.text = ("Click To Turn On");
                      if (Input.GetMouseButtonDown(0))
                      {
                          Cutter.TurnOnSaw();
                      } 
                  }else if(mouseHit.transform.tag == "SawButtonOn")
                  {
                      gM.message.text = ("Click To Turn Off");
                      if (Input.GetMouseButtonDown(0))
                      {
                          Cutter.TurnOffSaw();
                      } 
                  }else if(mouseHit.transform.tag == "Package")
                  {
                      oM = mouseHit.transform.GetComponent<ObjectManager>();
                      gM.message.text = ("Click To Pick Up, Press E to Open");
                      if (Input.GetMouseButtonDown(0))
                      { 
                          pUS.PickUp(mouseHit.transform.gameObject);
                      }
                      if (Input.GetKeyDown(KeyCode.E))
                      {
                          gM.OpenPackage(mouseHit.transform.gameObject);
                      } 
                  }else if(mouseHit.transform.tag == "EmptyPackage")
                  {
                      oM = mouseHit.transform.GetComponent<ObjectManager>();
                      packageAudioSource = mouseHit.transform.GetComponent<AudioSource>();
                      gM.message.text = ("Click To Pick Up, Press E to Close");
                      if (Input.GetMouseButtonDown(0))
                      { 
                          pUS.PickUp(mouseHit.transform.gameObject);
                      }
                      if (Input.GetKeyDown(KeyCode.E))
                      {
                          packageAudioSource.clip = packageA;
                          packageAudioSource.Play();
                          objectCasted = mouseHit.transform.gameObject;
                          iPM = objectCasted.GetComponent<inPackageManager>();
                           pM = Instantiate(closedPackage, objectCasted.transform.position, objectCasted.transform.rotation).GetComponent<PackageManager>();
                           pM.GetContents(iPM);
                           for(int i = 0; i < iPM.inPackage.Count; i++)
                           {
                               iPM.inPackage[i].gameObject.SetActive(false);
                           }
                           Destroy(objectCasted);
                           objectCasted = null;
                      }    
                  }else if(mouseHit.transform.tag == "BoxStack")
                  {
                      gM.message.text = ("Click To Pick Up");
                      if (Input.GetMouseButtonDown(0))
                      {
                          packageAudioSource = Instantiate(emptyPackage, packageSpawn.position, packageSpawn.rotation).GetComponent<AudioSource>();
                          packageAudioSource.Play();
                      } 
                  }else if(mouseHit.transform.tag == "Computer")
                  {
                      gM.message.text = ("Click To Turn On");
                      if (Input.GetMouseButtonDown(0))
                      {
                          if (gM.packageOpended)
                          {
                              gM.orderedItems.Clear(); //<----------------------------clears ordered items  <-------- this is clearing the package thats in the scene                                      
                              gM.computer = true;
                          }
                          else
                          {
                              gM.packageNoti.text = ("Open your package first!");
                          }
                          
                      } 
                  }else if(mouseHit.transform.tag == "Door")
                  {
                      if (gM.gameOver)
                      {
                          gM.message.text = ("Click To Open"); 
                          if (Input.GetMouseButtonDown(0))
                          {
                              DoorAudio.clip = open;
                              DoorAudio.Play();
                              loadEnd = true;

                          } 
                      }
                      else
                      {
                          gM.message.text = ("You have orders to finish");
                      }    
                  }else if(mouseHit.transform.tag == "Craft")
                  {
                      gM.message.text = ("Press C to Craft");
                  }else
                  {
                      gM.message.text = ("");
                  }
                }
                   
            } 
        }
        else
        {
            gM.message.text = ("");
        }
    }
}
