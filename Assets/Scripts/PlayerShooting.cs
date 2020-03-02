using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{


    public GameObject player_bullet;
    public float reload_time = 0.5f;
    public float bullet_speed = 10f;
    public int player_dmg;
    int starting_damage = 1;
    float last_fired;
    public float momentum = 0.02f;
    float v;
    float h;
    float v_cont;
    float h_cont;
    string aim_horz = "RightJoyStickX";
    string aim_vert = "RightJoyStickY";
    // Start is called before the first frame update
    void Start()
    {
        player_dmg = starting_damage;

        if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor){
            aim_horz = "RightJoyStickX_Wind";
            aim_vert = "RightJoyStickY_Wind";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_fired >= reload_time)
        {
            v = Input.GetAxisRaw("FireV");
            h = Input.GetAxisRaw("FireH");
            v_cont = Input.GetAxis(aim_vert);
            h_cont = Input.GetAxis(aim_horz);


            if (v != 0 | h != 0)
            {
                last_fired = Time.time;
                Fire(h, v);
            }
            else if(Mathf.Abs(v_cont) > 0 || Mathf.Abs(h_cont) > 0){
                last_fired = Time.time;
                Fire(h_cont, v_cont);
            }
        }
    }

    void Fire(float h, float v)
    {
        Vector3 player_pos = gameObject.transform.position;

        Vector3 shootDir = new Vector3(h, 0, v);
        shootDir = shootDir.normalized;

        var active_bullet = Instantiate(player_bullet, player_pos, Quaternion.identity);
        active_bullet.GetComponent<Rigidbody>().velocity = (shootDir + gameObject.GetComponent<Rigidbody>().velocity * momentum) * bullet_speed;
    }
}
