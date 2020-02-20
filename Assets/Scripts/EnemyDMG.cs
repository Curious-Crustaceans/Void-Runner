using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG : EnemyMind
{
    // Start is called before the first frame update
    
    public int enemy_health;

    void Awake() {
    	
    }

    public void TakeDMG(int dmg) {
       
    	enemy_health = enemy_health - dmg;
     
    }

    void Update(){
    	if (enemy_health <= 0)
    		Destroy(gameObject);
    }


}
