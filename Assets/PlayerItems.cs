using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    protected float damage = 1, shotSpeed = 12, shotsPerSecond = 2, burst = 1, spread = 1, delay = 1, multiplier = 1;
    public float speed = 8, zombs = 1;
    

    // Start is called before the first frame update

    // Update is called once per frame
    public void increaseStat(string stat, float x)
    {
        if (stat == "damage")
            damage += x;
        if (stat == "speed")
            speed += x;
        if (stat == "shotSpeed")
            shotSpeed += x;
        if (stat == "shotsPerSecond")
            shotsPerSecond += x;
        if (stat == "burst")
            burst += x;
        if (stat == "spread")
            spread += x;
        if (stat == "delay")
           shotsPerSecond*= x;
        if (stat == "multiplier")
            damage *= x;
        if (stat == "zombs")
            zombs += x;


    }

    public void onHit(Transform x)
    {
        BroadcastMessage("onHit", x);

    }
}
