using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject Player;
    public float maxDist;
    public float speed;
    int state;
    Animator animator;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player");
        state = 0;
        animator.SetInteger("state", state);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 2)
        {
            return;
        }
        Vector3 dirToPlayer = (Player.transform.position - transform.position).normalized;
        float distToPlayer = Vector3.Distance(Player.transform.position, transform.position);


        if (distToPlayer  < maxDist && Vector3.Angle(dirToPlayer, transform.forward) < 45)
        {
            Physics.Raycast(transform.position, dirToPlayer, out hit);
            Debug.DrawRay(transform.position, dirToPlayer * hit.distance, Color.yellow);
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Player")
            {
                state = 1;
                transform.LookAt(new Vector3(Player.transform.position.x, 0, Player.transform.position.z));
                this.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

            }
            else
            {
                state = 0;
            }
        }
        else
        {
            state = 0;
        }
        animator.SetInteger("state", state);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Player")
       {
            state = 2;
            animator.SetInteger("state", state);
       }
    }
}
