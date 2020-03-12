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
        string[] startDirections = new string[] { "Welcome back subject K063-P177","After your scheduled memory wipe you may need to relearn your abilities", "You can move with the left stick or WASD" };
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
            StartCoroutine(showText(new string[] { "Excellent, you can still walk. The new memory wipe procedure was a sucess!", "See if you can still harness your inate energy to fire projectiles.","Try using the right stick or the arrow keys."}));
        }

        bool temp = Input.GetAxis(aim_horz) != 0 || Input.GetAxis(aim_vert) != 0 || Input.GetAxisRaw("FireH") != 0 || Input.GetAxisRaw("FireV") != 0;
        if (temp && !completed[1] && !hit2){
            hit2 = true;
            StartCoroutine(showText(new string[] { "The source of your abilites is a topographically monotonic, zero point dimensional mobius flux", "For someone who only has a minute worth of memories... you can steal energy from a alternate dimension known as the void", "You can enter the Void with RT or space"})); 
        }

        if((Input.GetAxis(void_switch) > 0.1 || Input.GetKeyDown(KeyCode.Space)) && !completed[2] && !hit3){
            hit3 = true;
            StartCoroutine(showText(new string[] { "Wonderful", "Hostile entities live in the void and are attracted to the vibrations caused by your shift", "This facility stores numerous other anomalous items stored in white boxes", "Today we will test how they influence your abilities, so please collect the box"}));
            StartCoroutine(StartSetActive());
        }

        if (!hit4 && !completed[3] && itemSpawn.taken()){
            hit4 = true;
            StartCoroutine(showText(new string[] { "Facinating", "Please test the interaction on the turret", "For your safety, the bullets are holographic"}));
            playerItem.SetDamage(1f);
            GameObject.Find("Turret (2)").GetComponent<EnemyMind>().active = true;
        }


        if (GameObject.Find("Turret (2)") == null && !hit5 && !completed[4]){
            hit5 = true;
            StartCoroutine(showText(new string[]{"WARNING >>> CONTAINMENT BREACH IN SECTOR 13 >>> FACILITY LOCKDOWN ENGAGED >>> AUTOMATED DEFENSES ONLINE", "Huh...Ignore that...Everything is fine...", "In the mean time we will return you to your cell...I mean personal quarters"}));

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
            yield return new WaitForSeconds(5f);
        }
        if(count - 1 >= 0){
            completed[count - 1] = true;
        }
        completed[count] = false;
        count++;
    }

    IEnumerator Exit(){
        yield return new WaitForSecondsRealtime(16f);
        SceneManager.LoadScene("TitleScreen");
    }

    IEnumerator StartSetActive(){
        yield return new WaitForSecondsRealtime(10f);
        item.SetActive(true);
    }
}
