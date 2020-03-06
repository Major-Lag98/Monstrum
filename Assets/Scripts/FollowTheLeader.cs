using System.Collections.Generic;
using UnityEngine;

public class FollowTheLeader : MonoBehaviour
{
    public GameObject leader; // the game object to follow - assign in inspector
    public bool isMoving;
    bool isSprinting;
    public int place;
    public int steps; // number of steps to stay behind - assign in inspector
    Animator animator;

    Queue<Vector3> record = new Queue<Vector3>();
    private Vector3 lastRecord;
    private void Start()
    {
        transform.position = leader.transform.position;
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        animator.SetBool("Is Walking", isMoving);
        // record position of leader
        if (isMoving)
        {
            record.Enqueue(leader.transform.position);


            // remove last position from the record and use it for our own
            if (record.Count >= steps * place)
            {
                Vector2 direction = record.Peek() - transform.position == Vector3.zero ? lastRecord : record.Peek() - transform.position;
                lastRecord = direction;
                animator.SetFloat("Look X", direction.x);
                animator.SetFloat("Look Y", direction.y);
                //Debug.Log(direction);
                this.transform.position = record.Dequeue();

            }
        }
        else if (Vector2.Distance(leader.transform.position, transform.position) > .5f * place) //catchup
        {
            Vector2 direction = record.Peek() - transform.position == Vector3.zero ? lastRecord : record.Peek() - transform.position;
            lastRecord = direction;
            //isSprinting = true;
            animator.SetFloat("Look X", direction.x);
            animator.SetFloat("Look Y", direction.y);
            //animator.SetBool("Is Sprinting", isSprinting);
            Debug.Log("Here");
            this.transform.position = record.Dequeue();
        }
        if (Vector2.Distance(leader.transform.position, transform.position) > .7f * place)
        {
            isSprinting = true;
            
        }
        else
        {
            isSprinting = false;
        }
        Debug.Log(Vector2.Distance(leader.transform.position, transform.position));
        animator.SetBool("Is Sprinting", isSprinting);
        isMoving = false;

        //isSprinting = false;
        
    }
}