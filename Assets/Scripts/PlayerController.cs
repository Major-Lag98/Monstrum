using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector2 pos;

    public float speed = 2.0f;
    public float speedMultiplier = 1.5f;

    bool sprint = false;

    Animator animator;
    Vector2 lookDirection = Vector2.down;

    void Start()
    {
        animator = GetComponent<Animator>();
        pos = transform.position; // Take the current position
    }


    private void Update()
    {
        bool isMoving = false;
        bool tryingToMove = false;
        //check for colliders in the way
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1);


        //get controlls
        if (Input.GetKey(KeyCode.A) && (Vector2)transform.position == pos && hitleft.collider == null)
        {
            pos += Vector2.left;
            lookDirection = Vector2.left;
            tryingToMove = true;
            
        }
        else if (Input.GetKey(KeyCode.D) && (Vector2)transform.position == pos && hitright.collider == null)
        {
            pos += Vector2.right;
            lookDirection = Vector2.right;
            tryingToMove = true;

        }
        else if (Input.GetKey(KeyCode.W) && (Vector2)transform.position == pos && hitup.collider == null)
        {
            pos += Vector2.up;
            lookDirection = Vector2.up;
            tryingToMove = true;

        }
        else if (Input.GetKey(KeyCode.S) && (Vector2)transform.position == pos && hitdown.collider == null)
        {
            pos += Vector2.down;
            lookDirection = Vector2.down;
            tryingToMove = true;

        }

        if (Input.GetKey(KeyCode.LeftShift))//player sprinting?
        {
            sprint = true;
        }
        else
        {
            sprint = false;
        }

        if (tryingToMove || Vector2.Distance(transform.position, pos) > 0) //am i currently moving or trying to?
        {
            isMoving = true;
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetBool("Is Walking", isMoving);

    }

    void FixedUpdate()
    {
        

        if (sprint)//apply movement
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * speedMultiplier);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed);
        }
        

    }
}
