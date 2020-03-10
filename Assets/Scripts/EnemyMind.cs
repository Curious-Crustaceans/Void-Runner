using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMind  : MonoBehaviour
{
    public bool active = false;
    public bool dimVoid = false;
    public bool DOT = false;

    // Start is called before the first frame update
    public void setActive(bool act)
    { active = act; }
    public void setVoid(bool act)
    { dimVoid = act; }
    public bool getActive()
    { return active; }
    public bool getVoid()
    { return dimVoid; }


    public void StartDOT(GameObject particles, float damage, float time)
    {
        
        StartCoroutine(ApplyDOT(particles, damage, time));
    
    }
    IEnumerator ApplyDOT(GameObject particles, float damage, float time)
    {
        var parts = Instantiate(particles,transform);
        DOT = true;
       
        
        float appliedDamage = 0;
        while (appliedDamage <= damage)
        {
            gameObject.GetComponent<EnemyDMG>().TakeDMG(damage / 10);
            yield return new WaitForSeconds(time / 10);
            appliedDamage += damage / 10;
        
        }
        Destroy(parts);
        DOT = false;
    }
}
