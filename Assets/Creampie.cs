using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creampie : MonoBehaviour
{
    public GameObject bullet;
    float DMG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onBulletDestroy(Vector3 position)
    {

           
            DMG = transform.parent.GetComponent<PlayerItems>().getDamage()*.75f;
            position.y = 1.15f;
            float step = 2 * Mathf.PI / 5;
            float pos = step;
            for (int i = 0; i < 5; i++)
            {
                Vector3 direction = new Vector3(Mathf.Cos(pos), 0, Mathf.Sin(pos));

            if ((!Physics.Raycast(position, direction, 1f)))
            {
                var active_bullet = Instantiate(bullet, position + direction, Quaternion.identity);
                active_bullet.GetComponent<Rigidbody>().velocity = direction * transform.parent.GetComponent<PlayerItems>().getShotSpeed();
                active_bullet.GetComponent<PlayerBulletCollision>().bulletDMG = DMG;
                active_bullet.GetComponent<PlayerBulletCollision>().StartCoroutine("delay");
                active_bullet.GetComponent<PlayerBulletCollision>().canProc = false;
            }

                pos += step;

            
        }

    }
}
