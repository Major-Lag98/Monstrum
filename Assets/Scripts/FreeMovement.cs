using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{

    Vector2 move;
    Vector2 lookDirection = Vector2.down;

    public float speed = 1;

    Animator animator;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        //DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        bool walking = false;
        move = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            move += Vector2.left;
            lookDirection += Vector2.left;
            walking = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            move += Vector2.right;
            lookDirection += Vector2.right;
            walking = true;

        }
        if (Input.GetKey(KeyCode.W))
        {
            move += Vector2.up;
            lookDirection += Vector2.up;
            walking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move += Vector2.down;
            lookDirection += Vector2.down;
            walking = true;
        }

        lookDirection.Normalize();
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetBool("Is Walking", walking);

       
    }

    private void FixedUpdate()//apply movement
    {
        Vector2 position = rb.position;

        position = position + move * speed * Time.deltaTime;

        rb.MovePosition(position);
    }
}
