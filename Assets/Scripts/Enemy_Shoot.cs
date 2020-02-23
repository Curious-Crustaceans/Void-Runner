using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : EnemyMind
{
    // Start is called before the first frame update
    GameObject target;
    public GameObject point;
    public float damping = 1;
  
    Transform origin;
    public GameObject bullet;
    public float bullet_speed = 3f;
    public float time = 1.5f;
    bool locked = false;
    float lastfired = 0;
    public float recoilTime = 3;
    bool close = false;
    RaycastHit hit;
  

    void Start()
    {
        
        target = GameObject.Find("Player");
        active = false;
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        close = CheckClose();
        if ((close || locked)&& active)
        {
            point.SetActive(true);
            lookAt(target.transform);

            if (Time.time - lastfired >= recoilTime)
            {

                locked = true;
                StartCoroutine(Firing());
                lastfired = Time.time;


            }
            locked = false;
        }
        else
        {
            lastfired = Time.time;
            point.SetActive(false);
        }
    }

    IEnumerator Firing(){
        for (int i = 0; i < 5; i++)
        {
            Vector3 direction = transform.forward;
            direction.y = 0;
            Vector3 start = direction.normalized + point.transform.position;
            start.y = 1.2f;
            direction = direction.normalized * bullet_speed;
            EnemyFire(direction, start);
            yield return new WaitForSeconds(0.1F);
        }

    }
    void lookAt(Transform Target)
    {
        var rotation = Quaternion.LookRotation(Target.position - transform.position);
        rotation.x = 0; 
        rotation.z = 0;                
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void EnemyFire(Vector3 v, Vector3 start){
        //print("Vector direction");
        //print(v);
        //print("Vector origin");
        //print(start);
        //print("Vector Target");
        //print(t1);
        var active_bullet = Instantiate(bullet, start, Quaternion.identity);
        active_bullet.GetComponent<Rigidbody>().velocity = v;
        Destroy(active_bullet, 2.0f); //might change later
    }

    bool CheckClose(){

        
        Vector3 origin = transform.position;
        origin.y = 1;
        var rayDirection = target.transform.position - transform.position;
        rayDirection.y = 0;
       

        if (Physics.Raycast(origin, rayDirection, out hit, 20f)){
            
            if (hit.transform.gameObject == target)
            {
         
                //Vector3 distance = t1.position - origin.position;
                //float length = Mathf.Abs(distance.magnitude);
                return true;
            }
        }
        return false;
    }

   
}
