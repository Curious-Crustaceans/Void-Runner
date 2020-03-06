using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItem : MonoBehaviour
{
    public GameObject item;
    bool triggered;
    public string ItemName, FlavorText;
    TMPro.TextMeshProUGUI itemName;
    TMPro.TextMeshProUGUI flavorText;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        itemName = GameObject.Find("ItemName").GetComponent<TMPro.TextMeshProUGUI>();
        flavorText = GameObject.Find("FlavorText").GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (!triggered)
        {
           
                if (other.tag == "Player")
                {
                    triggered = true;
                    StartCoroutine(showText());
                    var newItem = Instantiate(item, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    newItem.transform.parent = player.transform;
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
