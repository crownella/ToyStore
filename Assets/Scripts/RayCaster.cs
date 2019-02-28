using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public float rayDis = 2f;
    public float mouseRayDis = 40f;
    public Transform placeHolder;
    public float placementMod = .1f;
    public Transform objectPosition;
    
    

    public Vector3 endOfRay;
    // Start is called before the first frame update
    void Start()
    {
        
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
        */

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * mouseRayDis);
        
        //endOfRay = new Vector3(mouseRay.direction.x, mouseRay.direction.y, mouseRay.direction.z);

        RaycastHit mouseHit;

        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out mouseHit, mouseRayDis))
        {

            if (mouseHit.transform.tag == "Surface")
            {
                placeHolder.transform.position = new Vector3(mouseHit.point.x,mouseHit.point.y + placementMod,mouseHit.point.z);
                
            }else if(mouseHit.transform.tag == "WallNorth")
            {
                placeHolder.transform.position = new Vector3(mouseHit.point.x + placementMod,mouseHit.point.y,mouseHit.point.z);
            }
            else if(mouseHit.transform.tag == "WallSouth")
            {
                placeHolder.transform.position = new Vector3(mouseHit.point.x - placementMod,mouseHit.point.y,mouseHit.point.z);
            }else if(mouseHit.transform.tag == "WallWest")
            {
                placeHolder.transform.position = new Vector3(mouseHit.point.x,mouseHit.point.y,mouseHit.point.z + placementMod);
            }else if(mouseHit.transform.tag == "WallEast")
            {
                placeHolder.transform.position = new Vector3(mouseHit.point.x,mouseHit.point.y,mouseHit.point.z - placementMod);
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
        
        
        //mouseRay.direction.position
    }
}
