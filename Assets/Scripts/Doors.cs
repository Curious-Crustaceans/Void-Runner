using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject walls;
    public GameObject doors;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setState(string state)
    {
        anim = doors.GetComponent<Animator>();
        if (state == "openInitial") {
            walls.SetActive(false);
            doors.SetActive(true);
        }
        if (state == "closed")
        {
            anim.SetBool("Open", false);
        
        }
        if (state == "open")
        {
            anim.SetBool("Open", true);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Movement>().canShift = false;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Movement>().canShift = true;

        }

    }
}
