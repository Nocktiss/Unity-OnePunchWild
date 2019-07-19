using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float distanceFromPlayer;
    public float distanceToAttack;

    private Transform target;

    Animator anim;
    string walkHash = "skeleton_walk";
    string attackHash = "skeleton_attack";
    string idleHash = "skeleton_idle";

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( (target.transform.position - transform.position).sqrMagnitude < distanceFromPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetTrigger(walkHash);
            Debug.Log("STEP 1");

            if ((target.transform.position - transform.position).sqrMagnitude < distanceToAttack)
            {
                anim.SetTrigger(attackHash);
                Debug.Log("STEP 2");
            }
        }
    }
}
