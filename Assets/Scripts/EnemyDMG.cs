using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int enemy_health;

    void Awake() {
    	enemy_health = 3;
    }

    public void TakeDMG(int dmg) {
    	enemy_health = enemy_health - dmg;
        Debug.Log("DMG for:");
        Debug.Log(dmg.ToString());
    }

    void Update(){
    	if (enemy_health <= 0)
    		Destroy(gameObject);
    }


}
