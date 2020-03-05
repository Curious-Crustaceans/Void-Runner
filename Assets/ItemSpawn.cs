using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemSpawn : MonoBehaviour
{
    private List<UnityEngine.Object> Items = new List<UnityEngine.Object>();
    GameObject randItem;
    // Start is called before the first frame update
    void Start()
    {
        Items = Resources.LoadAll("Items", typeof(GameObject)).ToList();
        randItem = (GameObject)Items[Random.Range(0, Items.Count)];
        GameObject newItem = Instantiate(randItem, transform);

       
        Items.Remove(randItem);
        if (Items.Count == 0)
            Items = Resources.LoadAll("Items", typeof(GameObject)).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
