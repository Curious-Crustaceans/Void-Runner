using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDMG : MonoBehaviour
{
    // Start is called before the first frame update
    
<<<<<<< Updated upstream
    public float player_health;
    float player_starting_health = 5;
    public float inv;
    float lastDamage;
=======
<<<<<<< Updated upstream
    public int player_health;
    int player_starting_health = 5;
=======
    public float player_health;
    float player_starting_health = 10;
    public float inv;
    float lastDamage;
>>>>>>> Stashed changes

    public HealthBar healthBar;
    
>>>>>>> Stashed changes

    void Awake() {
    	player_health = player_starting_health;
        healthBar.SetMaxHealth(player_starting_health);
    }

<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
    public void TakeDMG(int dmg) {
    	player_health = player_health - dmg;
        
=======
>>>>>>> Stashed changes
    public void TakeDMG(float dmg)
    {
        if (Time.time - lastDamage >= inv) { 
        player_health -= dmg;
        lastDamage = Time.time;
<<<<<<< Updated upstream
    }
=======
        
        healthBar.SetHealth(player_health);
    }
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    }

    void Update(){
    	if (player_health <= 0) {
    		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    	}

   }
}
