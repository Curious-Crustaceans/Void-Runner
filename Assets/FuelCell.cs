using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCell : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onShift()
    {
        var part = Instantiate(particles, transform.parent.transform.position,Quaternion.identity);
        Destroy(part, 1.5f);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4);
        foreach (Collider hitCol in hitColliders)
        {


            EnemyDMG enemyDMG = hitCol.transform.GetComponent<EnemyDMG>();
            if (enemyDMG != null)
            {

                enemyDMG.TakeDMG(gameObject.GetComponentInParent<PlayerItems>().getDamage());
               


            }
          

        }
    }
}
