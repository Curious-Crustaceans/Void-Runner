using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalShots : MonoBehaviour
{
    // Start is called before the first frame update

    Queue<Vector3[]>Fractal = new  Queue<Vector3[]>();
    Queue<GameObject> Shots = new Queue<GameObject>();
    Queue<float> damage = new Queue<float>();
    public GameObject CurrBullet;
    Vector3[] CurrInfo;
    float CurrDamage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onShoot(GameObject bullet)
    {

        Fractal.Enqueue(new Vector3[] { bullet.transform.position, bullet.GetComponent<Rigidbody>().velocity });
        
        damage.Enqueue(bullet.GetComponent<PlayerBulletCollision>().bulletDMG / 2);
    }

    public void onBulletDestroy(Vector3 hit)
    {
        if (Fractal.Count != 0)
        {
            CurrInfo = Fractal.Dequeue();

            CurrDamage = damage.Dequeue();
            if (CurrDamage >=  transform.parent.GetComponent<PlayerItems>().getDamage()/4)
            {
                var newBullet = Instantiate(CurrBullet, CurrInfo[0], Quaternion.identity);

                newBullet.GetComponent<Rigidbody>().velocity = CurrInfo[1];
                newBullet.transform.localScale = newBullet.transform.localScale * .5f;
                newBullet.GetComponent<PlayerBulletCollision>().bulletDMG = CurrDamage;
                newBullet.GetComponent<TrailRenderer>().widthMultiplier *= .5f;
                transform.parent.GetComponent<PlayerItems>().onShootBroadcast(newBullet);
            }
        }
    }
}
