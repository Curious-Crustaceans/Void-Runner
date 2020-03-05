using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VoidManger : MonoBehaviour
{
    int zombCount = 0;
    public float maxZombs = 3;
    Vector2 position;
    RaycastHit hit;
   
    public GameObject zombie;
    GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Player" && zombCount < maxZombs)
        {

            for (int i = 0; i < player.GetComponent<PlayerItems>().zombs; i++)
            { spawnZombie(); }
            zombCount += 1;

        }

    }

    void spawnZombie()
    {
        while (true)
        {
            position = Random.insideUnitCircle;
            Physics.Raycast(player.transform.position, new Vector3(position.x, 0, position.y), out hit, 100f);

            if (Mathf.Abs((hit.transform.position - player.transform.position).magnitude) > 8)
            {

                var zomb = Instantiate(zombie, hit.transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
