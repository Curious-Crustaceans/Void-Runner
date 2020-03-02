using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public int bulletDMG = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {



        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerDMG>().TakeDMG(bulletDMG);
            Destroy(gameObject);
        }
        else
            if (other.tag != "transparent" && other.tag != "Enemy" && other.tag != "EnemyTransparent")
        {
            Destroy(gameObject);
        }
    }
}
