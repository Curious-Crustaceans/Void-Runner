using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void MainMenu() {
    	
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("LevelManager"));
        SceneManager.LoadScene("TitleScreen");
    	
    }

    public void Restart() {
    	
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("LevelManager"));
        SceneManager.LoadScene("Level1");
    }
}
