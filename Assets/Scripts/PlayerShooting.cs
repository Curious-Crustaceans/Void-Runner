using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : PlayerItems
{

    public GameObject player_bullet;
    float last_fired;
    public float momentum = 0.02f;
    float v;
    float h;
    float v_cont;
    float h_cont;
    string aim_horz = "RightJoyStickX";
    string aim_vert = "RightJoyStickY";
    //float shotsPerSecond, shotSpeed, damage, burst, spread;

    // Start is called before the first frame update
    void Start()
    {


        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            aim_horz = "RightJoyStickX_Wind";
            aim_vert = "RightJoyStickY_Wind";
        }
        //shotsPerSecond = GetComponent<PlayerItems>().shotsPerSecond;
        //shotSpeed = GetComponent<PlayerItems>().shotSpeed;
        //damage = GetComponent<PlayerItems>().damage;
        //burst = GetComponent<PlayerItems>().burst;
        //spread = GetComponent<PlayerItems>().shotsPerSecond;

    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - last_fired) >= 1 / (shotsPerSecond*delay))
        {
            v = Input.GetAxisRaw("FireV");
            h = Input.GetAxisRaw("FireH");
            v_cont = Input.GetAxis(aim_vert);
            h_cont = Input.GetAxis(aim_horz);


            if (v != 0 | h != 0)
            {
                last_fired = Time.time;
                StartCoroutine(Firing(h, v));
            }
            else if (Mathf.Abs(v_cont) > 0 || Mathf.Abs(h_cont) > 0)
            {
                last_fired = Time.time;
                StartCoroutine(Firing(h_cont, v_cont));
            }
        }
    }







    void Fire(float h, float v)
    {
        Vector3 player_pos = gameObject.transform.position;

        Vector3 shootDir = new Vector3(h, 0, v);
        shootDir = shootDir.normalized;



        var active_bullet = Instantiate(player_bullet, player_pos, Quaternion.identity);
        active_bullet.GetComponent<Rigidbody>().velocity = (shootDir + gameObject.GetComponent<Rigidbody>().velocity * momentum) * shotSpeed;
        active_bullet.GetComponent<PlayerBulletCollision>().bulletDMG = damage*multiplier;
    }

    IEnumerator Firing(float h, float v)
    {
        for (int i = 0; i < burst; i++)
        {
            Fire(h, v);
            yield return new WaitForSeconds(.05f);
        }

    }
}