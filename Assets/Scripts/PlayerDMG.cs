using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDMG : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float player_health;
    float player_starting_health = 10;
    public float inv;
    float lastDamage;
    public HealthBar healthBar;
    public GameObject gameover;

    

    void Awake() {
    	player_health = player_starting_health;
        healthBar.SetMaxHealth(player_starting_health);
    }

    public void TakeDMG(float dmg)
    {
        if (Time.time - lastDamage >= inv) { 
        player_health -= dmg;
        lastDamage = Time.time;
        healthBar.SetHealth(player_health);
        StartCoroutine(Flasher(inv));
    }

    IEnumerator Flasher(float inv) 
    {
        int flashes = 3;
        float wait = inv/(flashes*2);
        for (int i = 0; i < flashes; i++)
        {
            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(wait);
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(wait);
        }
        
    }

    }

    public void GainDMG(float dmg)
    {
        player_health += dmg;
        if(player_health > player_starting_health){
            player_health = player_starting_health;
        }
        healthBar.SetHealth(player_health);
        StartCoroutine(Flasher(inv));

        IEnumerator Flasher(float inv)
        {
            int flashes = 3;
            float wait = inv / (flashes * 2);
            for (int i = 0; i < flashes; i++)
            {
                GetComponent<Renderer>().enabled = false;
                yield return new WaitForSeconds(wait);
                GetComponent<Renderer>().enabled = true;
                yield return new WaitForSeconds(wait);
            }

        }

    }

    public bool FullHealth(){
        return Mathf.Abs(player_health - player_starting_health) < 0.001;
    }



    void Update(){
    	if (player_health <= 0) {
    		gameover.SetActive(true);
            gameObject.SetActive(false);

    	}

   }

    private void OnLevelWasLoaded(int level)
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        gameover = GameObject.Find("GameOver");
        gameover.SetActive(false);
    }
}
