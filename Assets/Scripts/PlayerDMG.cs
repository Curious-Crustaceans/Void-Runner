using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDMG : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float player_health;
    float player_starting_health = 5;
    public float inv;
    float lastDamage;

    void Awake() {
    	player_health = player_starting_health;
    }

    public void TakeDMG(float dmg)
    {
        if (Time.time - lastDamage >= inv) { 
        player_health -= dmg;
        lastDamage = Time.time;
    }
    }

    void Update(){
    	if (player_health <= 0) {
    		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    	}

   }
}
