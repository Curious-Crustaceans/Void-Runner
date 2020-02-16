using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDMG : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int player_health;
    int player_starting_health = 5;

    void Awake() {
    	player_health = player_starting_health;
    }

    public void TakeDMG(int dmg) {
    	player_health = player_health - dmg;
        
    }

    void Update(){
    	if (player_health <= 0) {
    		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    	}

   }
}
