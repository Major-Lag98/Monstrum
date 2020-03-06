using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : MonoBehaviour
{

    Vector2 move;

    public Vector2 lookDirection;
    public float speed = 1;
    public float speedMultiplier = 2;
    public string startPoint; //when saving game, make new startpoint at player loc and name it accordingly.

    Animator animator;

    Rigidbody2D rb;

    static bool exists;

    public bool debugLeft;
    public bool debugRight;
    public bool debugUp;
    public bool debugDown;



    bool sprinting = false;

    FollowTheLeader[] followers;
    

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

        followers = FindObjectsOfType<FollowTheLeader>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        bool walking = false;
        move = Vector2.zero;


        if ((Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || debugLeft)
        {
            move += Vector2.left;
            lookDirection += Vector2.left;
            walking = true;

        }
        if ((Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) || debugRight)
        {
            move += Vector2.right;
            lookDirection += Vector2.right;
            walking = true;

        }
        if ((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || debugDown)
        {
            move += Vector2.up;
            lookDirection += Vector2.up;
            walking = true;
        }
        if ((Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) || debugUp)
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

        if (walking && followers.Length > 0)
        {
            foreach (FollowTheLeader followers in followers)
            {
                followers.isMoving = true;
                
            }
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
