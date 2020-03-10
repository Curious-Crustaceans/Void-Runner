using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProcGen : MonoBehaviour
{

    public int levelSize;


    Vector3[,] dungeon = new Vector3[21, 21];

    private List<UnityEngine.Object> ItemRooms = new List<UnityEngine.Object>();
    private List<UnityEngine.Object> SpecialRooms = new List<UnityEngine.Object>();
    private List<UnityEngine.Object> Boss = new List<UnityEngine.Object>();
    private List<UnityEngine.Object> FourRoom = new List<UnityEngine.Object>();
    public GameObject spawn;
    GameObject randRoom;
    //Initializes a matrix that represents the level. Each room is a vector3 where x is if the room exists and y is the number of adjacent rooms. Z is a way to keep track of which walls need to have connections. This number is represented by a psuedo binary number in base ten.
    // for x 
    //1 = regular room
    //2= Spawn
    //3= boss
    //4 = item room
    //5 = special room

    // Start is called before the first frame update
    void Start()
    {
        SpecialRooms = Resources.LoadAll("SpecialRooms", typeof(GameObject)).ToList();
        ItemRooms = Resources.LoadAll("ItemRooms", typeof(GameObject)).ToList();
        FourRoom = Resources.LoadAll("4", typeof(GameObject)).ToList();
       
        Boss = Resources.LoadAll("Boss", typeof(GameObject)).ToList();
        dungeon[11, 11].x = 2;
        IncAdj(11, 11);
        int i = 0;
        while (i < levelSize)
        {
            SpawnRoom();
            i += 1;

        }
        SpawnBoss();
        SpawnSpecialRoom();
        SpawnItemRoom();
        SpawnItemRoom();



        GenerateLevel();
    }

    // Update is called once per frame
    void SpawnRoom()
    {
        while (true)
        {
            int x = Random.Range(1, 21);
            int y = Random.Range(1, 21);
            if (dungeon[x, y].x == 0 & dungeon[x, y].y > 0)
            {
                float chance = dungeon[x, y].y;
                if (Random.Range(0, 4) > chance & chance != 0)
                {
                    dungeon[x, y].x = 1;
                    IncAdj(x, y);

                    break;
                }

            }


        }

    }
    void SpawnItemRoom()
    {
        
        
        while (true)
        {
            int x = Random.Range(1, 21);
            int y = Random.Range(1, 21);
       
            if (dungeon[x, y].x == 0 && dungeon[x, y].y == 1)
            {
                
                
                    dungeon[x, y].x = 4;
                    IncAdj(x, y,100);

                    break;
                
            }

        }
    }

    void SpawnSpecialRoom()
    {

        while (true)
        {
            int x = Random.Range(1, 21);
            int y = Random.Range(1, 21);

            if (dungeon[x, y].x == 0 && dungeon[x, y].y == 1)
            {


                dungeon[x, y].x = 5;
                IncAdj(x, y, 100);

                break;

            }

        }
    }
    void SpawnBoss()
    {
        while (true)
        {
            int x = Random.Range(1, 21);
            int y = Random.Range(1, 21);
            int distance = (Mathf.Abs(x - 11) + Mathf.Abs(y - 11));
            if (dungeon[x, y].x == 0 && dungeon[x, y].y == 1) {
               
                if (Random.Range(levelSize/4, levelSize) < distance)
                {
                    dungeon[x, y].x = 3;
                    IncAdj(x, y, 100);

                    break;
                }
        }
            
        }
    }

   
    void IncAdj(int x, int y, int z = 1)
    {
        dungeon[x + 1, y].y += z;
        dungeon[x - 1, y].y += z;
        dungeon[x, y + 1].y += z;
        dungeon[x, y - 1].y += z;

        dungeon[x + 1, y].z += 10001;
        dungeon[x - 1, y].z += 10100;
        dungeon[x, y + 1].z += 11000;
        dungeon[x, y - 1].z += 10010;
    }

    void GenerateLevel()
    {
        for (int k = 1; k < 21; k++) { 
            for (int l = 1; l < 21; l++)
            {
                if (dungeon[k, l].x == 1)
                {

                    randRoom = (GameObject)FourRoom[Random.Range(0, FourRoom.Count)];
                    GameObject newRoom = Instantiate(randRoom, new Vector3((l - 11) * 36, 0, (k - 11) * 36), Quaternion.identity);
                    int bits = (int) dungeon[k, l].z;
                  
                    string doorArray = Convert.ToString(bits, 10);
                    newRoom.GetComponent<RoomManager>().init(doorArray);
                    FourRoom.Remove(randRoom);
                    if (FourRoom.Count == 0)
                        FourRoom = Resources.LoadAll("4", typeof(GameObject)).ToList();


                }
                if (dungeon[k, l].x == 2)
                {

                    GameObject newRoom = Instantiate(spawn, new Vector3((l - 11) * 36, 0, (k - 11) * 36), Quaternion.identity);
                    int bits = (int)dungeon[k, l].z;

                    string doorArray = Convert.ToString(bits, 10);
                    newRoom.GetComponent<RoomManager>().init(doorArray);


                }
                if (dungeon[k, l].x == 3)
                {

                    GameObject newRoom = Instantiate((GameObject)Boss[Random.Range(0, Boss.Count)], new Vector3((l - 11) * 36, 0, (k - 11) * 36), Quaternion.identity);
                    int bits = (int)dungeon[k, l].z;

                    string doorArray = Convert.ToString(bits, 10);
                    newRoom.GetComponent<RoomManager>().init(doorArray);


                }

                if (dungeon[k, l].x == 4)
                {

                    GameObject newRoom = Instantiate((GameObject)ItemRooms[Random.Range(0, ItemRooms.Count)], new Vector3((l - 11) * 36, 0, (k - 11) * 36), Quaternion.identity);
                    int bits = (int)dungeon[k, l].z;

                    string doorArray = Convert.ToString(bits, 10);
                    newRoom.GetComponent<RoomManager>().init(doorArray);


                }
                if (dungeon[k, l].x == 5)
                {

                    GameObject newRoom = Instantiate((GameObject)SpecialRooms[Random.Range(0, SpecialRooms.Count)], new Vector3((l - 11) * 36, 0, (k - 11) * 36), Quaternion.identity);
                    int bits = (int)dungeon[k, l].z;

                    string doorArray = Convert.ToString(bits, 10);
                    newRoom.GetComponent<RoomManager>().init(doorArray);


                }


            } 
        
        
        }
    }
}
