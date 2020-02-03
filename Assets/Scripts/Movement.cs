using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    bool canMove = true;
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    Transform transf;                    // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    int dir = 1;
    public Camera cam;
    void Awake()
    {


        
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
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // Move the player around the scene.
            Move(h, v);
        }
        else
            canMove = true;
       
        

    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
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
