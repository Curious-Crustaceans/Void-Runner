using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void MainMenu() {
    	Debug.Log("MM");
    	SceneManager.LoadScene("TitleScreen");
    	
    }

    public void Restart() {
    	Debug.Log("R");
    	SceneManager.LoadScene("Anthony");
    	
    }
}
