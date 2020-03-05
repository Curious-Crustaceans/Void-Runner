using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStats : MonoBehaviour
{
    public string[] stats;
    public float[] amount;
    public string ItemName, FlavorText;
    GameObject player;
    GameObject canvas;
    TMPro.TextMeshProUGUI itemName;
    TMPro.TextMeshProUGUI flavorText;
    bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
       
        itemName = GameObject.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
        flavorText = GameObject.Find("FlavorText").GetComponent<TMPro.TextMeshProUGUI>();


    }

    private void OnTriggerEnter(Collider other)
    {

        if (!triggered)
        {
            for (int x = 0; x < stats.Length; x++)
                if (other.tag == "Player")
                {
                    triggered = true;
                    StartCoroutine(showText());
                    other.gameObject.GetComponent<PlayerItems>().increaseStat(stats[x], amount[x]);
                    gameObject.GetComponent<MeshRenderer>().enabled = false;

                }
        }
    }

    IEnumerator showText()
    {
        itemName.text = ItemName;
        flavorText.text = FlavorText;
        yield return new WaitForSeconds(3f);
        itemName.text = "";
        flavorText.text = "";
        Destroy(gameObject);
    }

    }
