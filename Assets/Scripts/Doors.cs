using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject walls;
    public GameObject doors;
    // Start is called before the first frame update
    void Start()
    {
        Animator anim = doors.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setState(string state)
    {
        if (state == "open")
            walls.SetActive(false);
            doors.SetActive(true);
    }
}
