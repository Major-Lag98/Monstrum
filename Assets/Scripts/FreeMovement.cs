using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{

    Vector2 move;
    public Vector2 lookDirection;

    public float speed = 1;
    public float speedMultiplier = 2;

    Animator animator;

    Rigidbody2D rb;

    static bool exists;

    public string startPoint;
    bool sprinting = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (!exists)
        {
            exists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
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

        if (Input.GetKey(KeyCode.LeftShift) && walking)
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }

        lookDirection.Normalize();
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetBool("Is Walking", walking);
        animator.SetBool("Is Sprinting", sprinting);

       
    }

    private void FixedUpdate()//apply movement
    {
        Vector2 position = rb.position;
        if (sprinting)
        {
            position += move * speed * speedMultiplier * Time.fixedDeltaTime;
        }
        else
        {
            position += move * speed * Time.fixedDeltaTime;
        }
        

        rb.MovePosition(position);
    }
}
