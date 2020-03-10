using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyTrooper : EnemyMind
{
    bool running = false;
    Vector2 direction;
   
    GameObject target;
    RaycastHit hit;
    float range;
   
    Vector3 startPosition;
    Animator anim;
    public GameObject bullet;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { if (active)
        {
            var rotation = Quaternion.LookRotation(target.transform.position - transform.position);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
            if (!running)
            {
                StartCoroutine(run());

            }
        }
    }

    IEnumerator run()
    {
        running = true;
        yield return new WaitForSeconds(3f);
        
        while (active)
        {
            while  (target.transform.position.y - transform.position.y < 5)
            {
                startPosition = target.transform.position;
                startPosition.y = 1;
                range = Random.Range(4, 12);
                direction = Random.insideUnitCircle * range;
               
                if (!Physics.Raycast(startPosition, new Vector3(direction.x, 0, direction.y), out hit, range))
                {
                    transform.position = startPosition + new Vector3(direction.x, 0, direction.y);
                    break;

                }
               
            }
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("Attack1Trigger");
            yield return new WaitForSeconds(.6f);
            var active_bullet = Instantiate(bullet,new Vector3(point.transform.position.x,1,point.transform.position.z),Quaternion.identity);
            yield return new WaitForSeconds(3f);






        }
    }
}
