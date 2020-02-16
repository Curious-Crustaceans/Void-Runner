using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{


    public GameObject player_bullet;
    public float reload_time = 0.5f;
    public float bullet_speed = 10f;
    public int player_dmg;
    int starting_damage = 10;
    float last_fired;
    public float momentum = 0.02f;
    float v;
    float h;
    // Start is called before the first frame update
    void Start()
    {
        player_dmg = starting_damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_fired >= reload_time)
        {
            v = Input.GetAxisRaw("FireV");
            h = Input.GetAxisRaw("FireH");


            if (v != 0 | h != 0)
            {
                last_fired = Time.time;
                Fire(h, v);
            }
        }
    }

    void Fire(float h, float v)
    {
        Vector3 player_pos = gameObject.transform.position;

        Vector3 shootDir = new Vector3(h, 0, v);


        var active_bullet = Instantiate(player_bullet, player_pos, Quaternion.identity);
        active_bullet.GetComponent<Rigidbody>().velocity = (shootDir + gameObject.GetComponent<Rigidbody>().velocity * momentum) * bullet_speed;
    }
}
