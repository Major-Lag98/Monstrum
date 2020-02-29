using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{

    Vector2 position;
    Vector2 lookDirection = Vector2.down;

    public float speed = 1;

    Animator animator;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool walking = false;
        
        if (Input.GetKey(KeyCode.A))
        {
            position += Vector2.left * speed * Time.deltaTime;
            lookDirection += Vector2.left;
            walking = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            position += Vector2.right * speed * Time.deltaTime;
            lookDirection += Vector2.right;
            walking = true;

        }
        if (Input.GetKey(KeyCode.W))
        {
            position += Vector2.up * speed * Time.deltaTime;
            lookDirection += Vector2.up;
            walking = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position += Vector2.down * speed * Time.deltaTime;
            lookDirection += Vector2.down;
            walking = true;
        }

        lookDirection.Normalize();
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetBool("Is Walking", walking);

        Debug.Log(walking);
        Debug.Log(rb.velocity);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
