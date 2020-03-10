using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour
{
    
    public void PlayGame() {
    	SceneManager.LoadScene("Anthony");

    }

    public void QuitGame(){
    	Application.Quit();
    }

    public void StartTutorial() {
    	SceneManager.LoadScene("Tutorial");
    }
	
}
