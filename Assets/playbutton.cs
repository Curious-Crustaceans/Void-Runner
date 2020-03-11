using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour
{
    public void PlayGame() {
    	SceneManager.LoadScene("Level1");

    }

    public void QuitGame(){
    	Application.Quit();
    }

    public void StartTutorial() {
    	SceneManager.LoadScene("Tutorial");
    }
	
}
