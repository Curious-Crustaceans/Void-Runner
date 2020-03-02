using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Use : MonoBehaviour
{
    public float scale_factor;
    public float time;
    Transform t1;
    bool shrinking = false;
    Vector3 scaling;
    GameObject go;
    PlayerDMG pdmg;

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("Heal_Cube");
        t1 = go.transform;
        scaling = new Vector3(scale_factor, scale_factor, scale_factor);
        pdmg = GameObject.Find("Player").GetComponent<PlayerDMG>();
    }

    // Update is called once per frame
    void Update()
    {
        if(t1.localScale.x < 1.4){
            Destroy(go);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        string obj = collision.gameObject.tag;
        if(obj == "Player"){
            bool full = pdmg.FullHealth();
            if (!full)
            {
                StartCoroutine(Shrink());
            }
        }
    }

    IEnumerator Shrink(){
        float x = t1.localScale.x * scale_factor;
        float y = t1.localScale.y * scale_factor;
        float z = t1.localScale.z * scale_factor;
        t1.localScale = new Vector3(x, y, x);
        pdmg.GainDMG(1);
        yield return new WaitForSecondsRealtime(time);
    }
}
