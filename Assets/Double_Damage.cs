using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_Damage : MonoBehaviour
{
    bool upgraded = false;
    float inv = 1f;
    PlayerShooting ps;
    // Start is called before the first frame update

    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        ps = player.GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            ps.setSecond();
            StartCoroutine(Flasher(inv));
            if(!upgraded){
                ps.Upgrade();
                upgraded = true;
            }
        }
    }


    IEnumerator Flasher(float inv)
    {
        int flashes = 3;
        float wait = inv / (flashes * 2);
        for (int i = 0; i < flashes; i++)
        {
            GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(wait);
            GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(wait);
        }

    }
}
