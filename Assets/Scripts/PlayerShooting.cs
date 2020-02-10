using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

	GameObject player;
	public GameObject player_bullet;
	public int reload_time = 1;
	public int bullet_speed = 1;
	float last_fired;
	public float offset = 1;
    // Start is called before the first frame update
    void Start()
    {
    	player = GameObject.Find("Capsule");
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (Time.time - last_fired >= reload_time)
    	{
	        if (Input.GetKey(KeyCode.I)) 
	        {
	        	Fire("up");
	        	last_fired = Time.time;
	        }
	        if (Input.GetKey(KeyCode.L))
	        {
	        	Fire("right");
	        	last_fired = Time.time;
	        }
	        if (Input.GetKey(KeyCode.J))
	        {
	        	Fire("left");
	        	last_fired = Time.time;
	        }
	        if (Input.GetKey(KeyCode.K))
	        {
	        	Fire("down");
	        	last_fired = Time.time;
	        }
	    }
    }

    void Fire(string dir)
    {
    	Vector3 player_pos = player.transform.position;
    	
    	Vector3 v = new Vector3(0,0,0);
    	if (dir == "up"){
    		v = new Vector3(0,0,1);
    	}
    	if (dir == "down"){
    		v = new Vector3(0,0,-1);
    	}
    	if (dir == "left"){
    		v = new Vector3(-1,0,0);
    	}
    	if (dir == "right"){
    		v = new Vector3(1,0,0);
    	}

		var active_bullet = Instantiate(player_bullet, player_pos + v*offset, Quaternion.identity);
        active_bullet.GetComponent<Rigidbody>().velocity = v * bullet_speed;
    }
}
