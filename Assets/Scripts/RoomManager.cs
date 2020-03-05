using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RoomManager : MonoBehaviour
{
    List<GameObject> doors = new List<GameObject>();
    // Start is called before the first frame update
    private bool active = false;
    public GameObject doorN;
    public GameObject door;
    public GameObject doorS;
    public GameObject doorW;
    GameObject player;
    public GameObject zombie;
    private List<GameObject> roomEnemies = new List<GameObject>();
    
    private bool alive = false;
    private bool flip = true;
    
    void Update()
    {
        
       
 

        if (active)
        {
           
            
            alive = false;
            foreach (GameObject enemy in roomEnemies)
            { if (enemy != null)
                    alive = true;
            }
            if (!alive)
            {
                openDoors();
                active = false;
            }

        }
    }

    public void init(string doorArray)
    {
       
        if (doorArray[2] == '1')
        {
            doors.Add(doorN);

        }
        if (doorArray[3] == '1')
        {
            doors.Add(door);

        }
        if (doorArray[4] == '1')
        {
            doors.Add(doorS);

        }
        if (doorArray[1] == '1')
        {
            doors.Add(doorW);
        }
        foreach (Transform child in gameObject.transform)
        {
            if (child.tag == "Enemy")
                roomEnemies.Add(child.gameObject);
        }
        player = GameObject.Find("Player");
        openDoorsInitial();
     


    }
    
    void closeDoors()
    {
        foreach (GameObject door in doors)
        { 
            door.GetComponent<Doors>().setState("closed");
        }
    }
    void openDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Doors>().setState("open");
        }
    }

    void openDoorsInitial()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Doors>().setState("openInitial");
        }
    }

    void activateEnemies(bool x)
    {
        foreach (GameObject enemy in roomEnemies)
        {
            if (enemy != null)
            {
                enemy.GetComponent<EnemyMind>().setActive(x);
            }
        }
    }
    void voidEnemies(bool x)
    {
        foreach (GameObject enemy in roomEnemies)
        {
            enemy.GetComponent<EnemyMind>().setVoid(x);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
            closeDoors();
            activateEnemies(true);
            
        }
        
    }






}
