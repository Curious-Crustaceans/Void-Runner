using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public bool canShift = true;
    bool canMove = true;
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    Transform transf;                    // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    int direction = 1;
    public Camera cam;
    Vector3 goalV;
    bool hit0 = true;
    string void_switch = "RT";
    float speed;
    


    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            void_switch = "RT_Wind";
        }
     
    }


    void Awake()
    {


        goalV.y = 0;
        transf=GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown("space") || (Input.GetAxis(void_switch) > 0.99 && hit0))
        {
            hit0 = false;
            Shift(direction);
           
        }
        if (canMove)
        {
            // Store the input axes.
            goalV.x = Input.GetAxisRaw("Horizontal");
            goalV.z = Input.GetAxisRaw("Vertical");

            goalV.Normalize();
            
           
        }
        else
            canMove = true;

        if(Input.GetAxis(void_switch) < 0.1){
            hit0 = true;
        }
       
        

    }
    void FixedUpdate()
    {
        speed = gameObject.GetComponent<PlayerItems>().speed;
        Move(goalV);
    }

    void Move(Vector3 goal_velocity)
    {
     

       
        playerRigidbody.AddForce((goal_velocity*speed -playerRigidbody.velocity)*15);
    }

    void Shift(int dir)
    {

       
        if (canShift)
        {
           
            canMove = false;
            if (dir == 1)
            {
                transf.SetPositionAndRotation(transform.position + new Vector3(0, -50, 0), transf.rotation);
                cam.transform.SetPositionAndRotation(cam.transform.position + new Vector3(0, -50, 0), cam.transform.rotation);
                direction = -1;
            }
            else
            {
                transf.SetPositionAndRotation(transform.position + new Vector3(0, 50, 0), transf.rotation);
                cam.transform.SetPositionAndRotation(cam.transform.position + new Vector3(0, 50, 0), cam.transform.rotation);
                direction = 1;
            }
            gameObject.GetComponent<PlayerItems>().onShiftBroadcast();
            
        }
    }
}
