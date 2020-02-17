using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject target;
    Transform t1;
    Transform origin;
    public GameObject bullet;
    public float bullet_speed = 3f;
    public float time = 1.5f;
    public int bullets = 3;
    float lastfired = 0;
    public float recoilTime = 3;
    bool close = false;
    bool determining = false;

    void Start()
    {
        target = GameObject.Find("Player");
        t1 = target.transform;
        origin = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Time.time - lastfired >= recoilTime)
        {
            if (!determining)
            {
                determining = true;
                close = CheckClose();
                if (close)
                {
                    StartCoroutine(Firing());
                    lastfired = Time.time;
                }
                determining = false;
            }
        }
    }

    IEnumerator Firing(){
        for (int i = 0; i < bullets; i++)
        {
            Vector3 direction = t1.position - origin.position;
            direction.y = 0;
            Vector3 start = direction.normalized + origin.position;
            start.y = 1.2f;
            direction = direction.normalized * bullet_speed;
            EnemyFire(direction, start);
            yield return new WaitForSeconds(time);
        }

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
        Vector3 distance = t1.position - origin.position;
        float length = Mathf.Abs(distance.magnitude);
        return length < 9f;
    }

   
}
