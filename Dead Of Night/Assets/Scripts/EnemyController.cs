using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    public float maxDist;
    //int state;
    Animator animator;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        //state = 0;
        animator.SetInteger("state", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirToPlayer = (Player.transform.position - transform.position).normalized;
        float distToPlayer = Vector3.Distance(Player.transform.position, transform.position);


        if (distToPlayer  < maxDist && Vector3.Angle(dirToPlayer, transform.forward) < 45)
        {
            Physics.Raycast(transform.position, dirToPlayer, out hit);
            Debug.DrawRay(transform.position, dirToPlayer * distToPlayer, Color.yellow);
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Player")
            {
                animator.SetInteger("state", 1);
                transform.LookAt(Player.transform);
            }
            
        }
        else //if (state < 2)
        {
            animator.SetInteger("state", 0);
        }
    }
}
