using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pepper : MonoBehaviour
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

    public void onHit(GameObject hit)
    {
       if(!hit.GetComponent<EnemyMind>().DOT)
        hit.GetComponent<EnemyMind>().StartDOT(particles, transform.parent.GetComponent<PlayerItems>().getDPS(), 10);
    }
}
