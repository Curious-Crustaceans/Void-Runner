using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int scene = 3;
    bool changed = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
            if (GameObject.Find("Boss") == null)
            {
                GameObject.Find("Charge_Enemy").GetComponent<EnemyDMG>().enemy_health = 0;
            }
            else
            {
                GameObject.Find("Boss").GetComponent<EnemyDMG>().enemy_health = 0;
            }
        }

    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void EndGame(){
        //Destroy Player
        Destroy(GameObject.Find("Player"));
        //Load the Title Scene
        SceneManager.LoadScene("TitleScreen");
        //Destroy this gameovject
        Destroy(GameObject.Find("LevelManager"));
    }

    public void NextLevel(){
        if (scene == 5)
        {
            EndGame();
        }
        else
        {
            scene++;
            SceneManager.LoadScene(scene);
            Vector3 pos = player.transform.position;
            player.transform.position = new Vector3(0, pos.y, 0);
            player.GetComponent<Movement>().UpdateCamera();
        }
    }
}
