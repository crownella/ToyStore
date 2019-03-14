using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;
    public Camera cam;
    private float pitch; //mouse up/down
    private float yaw;//mouse left/right
    public float fpForback; //inputfloat w/s
    public float fpStrafe;//inputfloat a/d
    private Vector3 inputVelocity; //cumilative vel to move character
    public float velocityMod; //veloctiy timer this modifier
    public float sensX;
    public float sensY;
    public GameManager gM;

    private float verticalLook = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gM = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gM.computer == false)
        {
            yaw = Input.GetAxis("Mouse X") * sensX;
            transform.Rotate(0,yaw,0);

            pitch = Input.GetAxis(("Mouse Y")) * sensY;
            
            verticalLook += -pitch;
            verticalLook = Mathf.Clamp(verticalLook, -60f, 60f);
            
            
            //cam.transform.Rotate(-pitch,0,0);
            cam.transform.localEulerAngles = new Vector3(verticalLook,0f,0f);

            fpForback = Input.GetAxis("Vertical");
            fpStrafe = Input.GetAxis("Horizontal");

            inputVelocity = transform.forward * fpForback;
            inputVelocity += transform.right * fpStrafe;
        }

    }

    void FixedUpdate()
    {
        if (gM.computer == false)
        {
            rb.velocity = inputVelocity * velocityMod + (Physics.gravity * .69f);
        }
    }
}
