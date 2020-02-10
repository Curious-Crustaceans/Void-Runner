using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    Vector2 playerCoords = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < (playerCoords.x * 36) - 18)
        {
            playerCoords.x -= 1;
            UpdateCamera();
        }
        if (player.transform.position.x > (playerCoords.x * 36) + 18)
        {
            playerCoords.x += 1;
            UpdateCamera();
        }
        if (player.transform.position.z < (playerCoords.y * 36) - 18)
        {
            playerCoords.y -= 1;
            UpdateCamera();
        }
        if (player.transform.position.z > (playerCoords.y * 36) + 18)
        {
            playerCoords.y += 1;
            UpdateCamera();
        }
    }



    void UpdateCamera()
    {
        cam.transform.SetPositionAndRotation(new Vector3(playerCoords.x *36, 30, playerCoords.y * 36), cam.transform.rotation);
    }
}
