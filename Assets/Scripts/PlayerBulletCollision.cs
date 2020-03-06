using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{

    bool canDamage = true;
    public bool canProc = true;
	public float bulletDMG;
    GameObject player;
   
	
    // Start is called before the first frame update
    void Start(){
    	player = GameObject.Find("Player");
        
    }


    // Update is called once per frame
    IEnumerator delay()
    {
        canDamage = false;
        yield return new WaitForSeconds(.2f);
        canDamage = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "transparent")
            
            destroy();

        if (other.tag == "Enemy")
        {

            if (canDamage)
            {
                other.gameObject.GetComponent<EnemyDMG>().TakeDMG(bulletDMG);

                player.GetComponent<PlayerItems>().onHitBroadcast(other.gameObject);

                destroy();
            }
                
            
        }
    }
    private void destroy()
    {

        if (canProc)
            player.GetComponent<PlayerItems>().onBulletDestroyBroadcast(transform.position - gameObject.GetComponent<Rigidbody>().velocity*.1f);
   
           Destroy(gameObject);
    }

}
