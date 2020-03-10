using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    PlayerItems playerItem;
    ItemSpawn itemSpawn;
    TMPro.TextMeshProUGUI directions;
    string aim_horz = "RightJoyStickX";
    string aim_vert = "RightJoyStickY";
    string void_switch = "RT";
    bool[] completed = new bool[] {true, true, true, true, true}; //this controls order; other bools ensures code only runs once
    bool hit1 = false;
    bool hit2 = false;
    bool hit3 = false;
    bool hit4 = false;
    bool hit5 = false;
    int count = 0;
    GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            aim_horz = "RightJoyStickX_Wind";
            aim_vert = "RightJoyStickY_Wind";
            void_switch = "RT_Wind";
        }

        directions = GameObject.Find("Direct").GetComponent<TMPro.TextMeshProUGUI>();
        string[] startDirections = new string[]{ "Welcome to the Tutorial!","Meet your pal, Phil the Pill", "Try moving Phil with the left Joystick or WASD"};
        StartCoroutine(showText(startDirections));
        playerItem = GameObject.Find("Player").GetComponent<PlayerItems>();
        playerItem.SetDamage(0f);
        item = GameObject.Find("ItemPedastal");
        item.SetActive(false);
        itemSpawn = item.GetComponent<ItemSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) && !completed[0] && !hit1){
            hit1 = true;
            StartCoroutine(showText(new string[] { "Great!", "Try shooting using right joystick or the arrow keys"}));
        }

        bool temp = Input.GetAxis(aim_horz) != 0 || Input.GetAxis(aim_vert) != 0 || Input.GetAxisRaw("FireH") != 0 || Input.GetAxisRaw("FireV") != 0;
        if (temp && !completed[1] && !hit2){
            hit2 = true;
            StartCoroutine(showText(new string[] { "Great!", "Try using the right trigger or the space bar to enter and exit the void"})); 
        }

        if((Input.GetAxis(void_switch) > 0.1 || Input.GetKeyDown(KeyCode.Space)) && !completed[2] && !hit3){
            hit3 = true;
            StartCoroutine(showText(new string[] { "Great!", "Be careful of zombies in the void", "Now pick up the white box item", "It will give you a powerup"}));
            StartCoroutine(StartSetActive());
        }

        if (!hit4 && !completed[3] && itemSpawn.taken()){
            hit4 = true;
            StartCoroutine(showText(new string[] { "Nice!", "Now try to kill the turret", "Watch out for bullets"}));
            playerItem.SetDamage(1f);
            GameObject.Find("Turret (2)").GetComponent<EnemyMind>().active = true;
        }


        if (GameObject.Find("Turret (2)") == null && !hit5 && !completed[4]){
            hit5 = true;
            StartCoroutine(showText(new string[]{"Congratulations you killed the turret", "This is the end of the tutorial", "Enjoy your Journey in VoidRunner"}));

        }


        if(hit5){
            StartCoroutine(Exit());
        }


    }

    IEnumerator showText(string[] message)
    {
        directions.text = "";
        foreach(string s in message){
            directions.text = s;
            yield return new WaitForSeconds(3f);
        }
        if(count - 1 >= 0){
            completed[count - 1] = true;
        }
        completed[count] = false;
        count++;
    }

    IEnumerator Exit(){
        yield return new WaitForSecondsRealtime(11f);
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator StartSetActive(){
        yield return new WaitForSecondsRealtime(10f);
        item.SetActive(true);
    }
}
