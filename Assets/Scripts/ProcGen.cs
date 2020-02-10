using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProcGen : MonoBehaviour
{
    
    public int levelSize;
    
    Vector3 [,] dungeon =  new Vector3[21,21];
    
    private UnityEngine.Object[] FourRoom;
    //Initializes a matrix that represents the level. Each room is a vector2 where x is if the room exists and y is the number of adjacent rooms. Z is a way to keep track of which walls need to have connections. This number is represented by a psuedo binary number in base ten.

    // Start is called before the first frame update
    void Start()
    {
        FourRoom = Resources.LoadAll("4",typeof(GameObject));
        dungeon[11, 11].x = 1;
        IncAdj(11, 11);
        int i = 0;
        while (i < levelSize)
        {
            SpawnRoom();
            i += 1;
            
        }
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

    void IncAdj(int x, int y)
    {
        dungeon[x + 1, y].y += 1;
        dungeon[x - 1, y].y += 1;
        dungeon[x, y + 1].y += 1;
        dungeon[x, y - 1].y += 1;

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

                    GameObject newRoom = Instantiate((GameObject)FourRoom[Random.Range(0, FourRoom.Length)], new Vector3((l - 11) * 36, 0, (k - 11) * 36), Quaternion.identity);
                    int bits = (int) dungeon[k, l].z;
                  
                    string doorArray = Convert.ToString(bits, 10);
                    newRoom.GetComponent<RoomManager>().init(doorArray);
               
                    
                }
            
            
            } 
        
        
        }
    }
}
