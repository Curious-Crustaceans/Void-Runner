using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;            // The speed that the player will move at.

   
    bool canMove = true;
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    Transform transf;                    // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    int dir = 1;
    public Camera cam;
    Vector3 goalV;
    void Awake()
    {


        goalV.y = 0;
        transf=GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print(dir);
            Shift(dir);
            dir *= -1;
            canMove = false;
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
       
        

    }
    void FixedUpdate()
    {
        Move(goalV);
    }

    void Move(Vector3 goal_velocity)
    {
     

       
        playerRigidbody.AddForce((goal_velocity*10 -playerRigidbody.velocity)*speed);
    }

    void Shift(int dir)
    {
        if (dir == 1)
        {
            transf.SetPositionAndRotation(transform.position + new Vector3(0, -50, 0), transf.rotation);
            cam.transform.SetPositionAndRotation(cam.transform.position + new Vector3(0, -50, 0), cam.transform.rotation);
        }
        else
        {
            transf.SetPositionAndRotation(transform.position + new Vector3(0, 50, 0), transf.rotation);
            cam.transform.SetPositionAndRotation(cam.transform.position + new Vector3(0, 50, 0), cam.transform.rotation);
        }
    }
}
