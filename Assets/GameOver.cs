using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void MainMenu() {
    	Debug.Log("MM");
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("LevelManager"));
        SceneManager.LoadScene("TitleScreen");
    	
    }

    public void Restart() {
    	Debug.Log("R");
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("LevelManager"));
        SceneManager.LoadScene("Level1");
    }
}
