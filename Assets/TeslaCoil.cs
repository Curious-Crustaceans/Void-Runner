using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoil : MonoBehaviour
{

    int chainNumber;
    float chance;
    GameObject chain;
    LineRenderer line;
    List<Vector3> posList = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (line.enabled)
        { line.SetPositions(posList.ToArray()); }
    }

    public void onHit(GameObject hit)
    {
        posList.Clear();
        posList.Add(hit.transform.position);
        Collider[] hitColliders = Physics.OverlapSphere(hit.transform.position, 10);
        foreach (Collider hitCol in hitColliders)
        {

           
            EnemyDMG enemyDMG = hitCol.transform.GetComponent<EnemyDMG>();
            if (enemyDMG != null && hit != hitCol.gameObject)
            {
                posList.Add(hitCol.transform.position);
                enemyDMG.TakeDMG(gameObject.GetComponentInParent<PlayerItems>().getDamage()/4);
                
                
            }

           
        }
        line.positionCount = posList.Count;
        line.SetPositions(posList.ToArray());
        StartCoroutine(delay());
        //chain = FindClosestEnemy(hit);

        //if (chain != null && chain.GetComponent<EnemyMind>().active)
        //{
        //    line.enabled = true;
        //    line.SetPosition(0, hit.transform.position);
        //    line.SetPosition(1, chain.transform.position);


        //    StartCoroutine(delay());
        //    chain.GetComponent<EnemyDMG>().TakeDMG(transform.parent.GetComponent<PlayerItems>().getDamage() / 2);


        //}


    }

    //public GameObject FindClosestEnemy(GameObject hit)
    //{
    //    GameObject[] gos;


    //    gos = GameObject.FindGameObjectsWithTag("Enemy");

    //    GameObject closest = null;
    //    float distance = 100;


    //    foreach (GameObject go in gos)
    //    {

    //        if (go != hit)
    //        {
    //            Vector3 diff = go.transform.position - hit.transform.position;
    //            float curDistance = diff.sqrMagnitude;
    //            if (curDistance < distance)
    //            {
    //                closest = go;
    //                distance = curDistance;
    //            }
    //        }
    //    }
    //    return closest;
    //}
    IEnumerator delay()
    {
        line.enabled = true;
        yield return new WaitForSeconds(.1f);
        line.enabled = false;
            } 

}