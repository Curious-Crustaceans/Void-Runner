using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
	public Collider col1;
	public GameObject col2;
    // Start is called before the first frame update
    void Start()
    {
    	
        Physics.IgnoreCollision(col1, col2.GetComponent<CapsuleCollider>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
    	

        //Destroy(this.gameObject);
    }
}
