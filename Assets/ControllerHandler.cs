using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerHandler : MonoBehaviour
{
    string press = "A";
    int pos = 1;
    TMPro.TextMeshProUGUI pbt;
    TMPro.TextMeshProUGUI tbt;
    TMPro.TextMeshProUGUI qbt;
    Color c1;
    Color c2;
    bool hit0 = true;

    // Start is called before the first frame update
    void Start()
    {
        pbt = GameObject.Find("text").GetComponent<TMPro.TextMeshProUGUI>();
        tbt = GameObject.Find("text1").GetComponent<TMPro.TextMeshProUGUI>();
        qbt = GameObject.Find("text2").GetComponent<TMPro.TextMeshProUGUI>();
        pbt.color = Color.magenta;
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            press = "A_Wind";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0.9 && hit0){
            hit0 = false;
            MoveRight();
        }
        else if(Input.GetAxisRaw("Horizontal") < -0.9 && hit0){
            hit0 = false;
            MoveLeft();
        }

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1){
            hit0 = true;
        }

        if(Input.GetButton(press)){
            if(pos == 1){
                SceneManager.LoadScene("Level1");
            }
            else if(pos == 0){
                SceneManager.LoadScene("Tutorial");
            }
            else{
                Application.Quit();
            }
        }
    }

    public void MoveLeft(){
        if(pos > 0){
            pos--;
            if (pos == 1)
            {
                pbt.color = Color.magenta;
                qbt.color = Color.white;
            }
            else
            {
                tbt.color = Color.magenta;
                pbt.color = Color.white;
            }
        }
    }

    public void MoveRight(){
        if(pos < 2){
            pos++;
            if(pos == 1){
                pbt.color = Color.magenta;
                tbt.color = Color.white;
            }
            else{
                qbt.color = Color.magenta;
                pbt.color = Color.white;
            }
        }
    }
}
