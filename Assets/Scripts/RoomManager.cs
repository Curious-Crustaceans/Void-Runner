using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomManager : MonoBehaviour
{
    List<GameObject> doors = new List<GameObject>();
    // Start is called before the first frame update
    public GameObject doorN;
    public GameObject door;
    public GameObject doorS;
    public GameObject doorW;
    public GameObject player;

    void Update()
    {
        if ((gameObject.transform.position +  -player.transform.position).magnitude > 8)
             openDoors();
            else
            closeDoors();
                
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

        openDoors();

    }

    void closeDoors()
    {
        foreach (GameObject door in doors)
        { 
            door.GetComponent<Doors>().setState("close");
        }
    }
    void openDoors()
    {
        foreach (GameObject door in doors)
        {
            door.GetComponent<Doors>().setState("open");
        }
    } 




}
