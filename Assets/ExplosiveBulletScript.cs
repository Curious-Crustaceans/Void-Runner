using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBulletScript : MonoBehaviour
{
   
    GameObject target;
    Vector3 distVector;
    float distance;
    Vector3 direction;
    
    public GameObject parts;
    float gravity = 10f;
    
  
    float theta;
    float yVelocity;
    float hVelocity;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.Find("Player");

        velocity = target.transform.position;
            velocity.y = 0;
        distance = Vector3.Distance(transform.position,velocity)-1.54f;

       


        theta = (Mathf.PI / 2)-(Mathf.Asin(gravity * distance / 400))/2;

        if (float.IsNaN(theta))
        { theta = Mathf.PI / 4; }

       
        yVelocity = 20* Mathf.Sin(theta);
        hVelocity = 20 * Mathf.Cos(theta);
        distVector = target.transform.position - transform.position;
       
        distVector = distVector.normalized * hVelocity;
        distVector.y = yVelocity;

        gameObject.GetComponent<Rigidbody>().velocity = distVector;




    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, -1.75f*gravity, 0);
        if (transform.position.y < 0) 
        {
            var part = Instantiate(parts, transform.position, Quaternion.identity);
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3);
            foreach (Collider hitCol in hitColliders)
            {
                if (hitCol.gameObject.name == "Player")
                {
                    hitCol.gameObject.GetComponent<PlayerDMG>().TakeDMG(2);

                }
            }
            Destroy(part, 1.5f);
            Destroy(gameObject);
        }

    }
    
}
