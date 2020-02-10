using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
	
    // Start is called before the first frame update
    

    // Update is called once per frame
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            Destroy(gameObject);
    }
}
