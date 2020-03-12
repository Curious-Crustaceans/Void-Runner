using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    GameObject button;
    GameObject button1;
    int pos = 0;
    string press = "A";
    bool hit0 = true;
    bool signal = false;

    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            press = "A_Wind";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (signal)
        {
            if (Input.GetAxisRaw("Vertical") > 0.9 && hit0)
            {
                hit0 = false;
                MoveUp();
            }
            else if (Input.GetAxisRaw("Vertical") < -0.9 && hit0)
            {
                hit0 = false;
                MoveDown();
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.1)
            {
                hit0 = true;
            }

            if (Input.GetButton(press))
            {
                if (pos == 0)
                {
                    Destroy(GameObject.Find("Player"));
                    Destroy(GameObject.Find("LevelManager"));
                    SceneManager.LoadScene("TitleScreen");
                }
                else if (pos == 1)
                {
                    Destroy(GameObject.Find("Player"));
                    Destroy(GameObject.Find("LevelManager"));
                    SceneManager.LoadScene("Level1");
                }
            }
        }
    }

    public void FindReference(){
        button1 = GameObject.Find("Button");
        button = GameObject.Find("Button (1)");
        button.GetComponent<Image>().color = Color.magenta;
        signal = true;
    }

    public void MoveUp(){
        if(pos > 0){
            pos--;
            button.GetComponent<Image>().color = Color.magenta;
            button1.GetComponent<Image>().color = Color.white;
        }
    }

    public void MoveDown(){
        if(pos < 1){
            pos++;
            button.GetComponent<Image>().color = Color.white;
            button1.GetComponent<Image>().color = Color.magenta;
        }
    }
}
