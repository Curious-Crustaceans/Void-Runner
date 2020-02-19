using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMind  : MonoBehaviour
{
    public bool active = false;
    public bool dimVoid = false;

    // Start is called before the first frame update
    public void setActive(bool act)
    { active = act; }
    public void setVoid(bool act)
    { dimVoid = act; }
    public bool getActive()
    { return active; }
    public bool getVoid()
    { return dimVoid; }
}
