using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float enemy_health;
    public HealthBar enemy_health_bar;
    Rigidbody rb;
    bool changed = false;

    void Awake() {
        enemy_health_bar.SetMaxHealth(enemy_health);
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDMG(float dmg) {
       
    	enemy_health = enemy_health - dmg;
        enemy_health_bar.SetHealth(enemy_health);
    }

    void Update(){
        if (enemy_health <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerItems>().onKillBroadcast(transform.position);

            if((rb.name == "Boss" || rb.name == "Charge_Enemy") && !changed){
                GameObject.Find("LevelManager").GetComponent<LevelManager>().NextLevel();
                changed = true;
                Destroy(gameObject);
            }
            else{
                Destroy(gameObject);
            }
        }
    }


}
