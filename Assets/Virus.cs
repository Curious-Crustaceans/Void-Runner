using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3);
        foreach (Collider hitCol in hitColliders)
        {


            EnemyMind enemyMind = hitCol.transform.GetComponent<EnemyMind>();
            if (enemyMind != null && !enemyMind.DOT)
            {
                enemyMind.StartDOT(particles, transform.parent.GetComponent<PlayerItems>().getDPS()/2, 5);


            }


        }
    }
}
