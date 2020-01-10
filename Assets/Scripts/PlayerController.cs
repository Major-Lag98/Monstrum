using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Vector3 pos;

    public float speed = 2.0f;
    public float speedMultiplier = 1.5f;

    bool sprint = false;

    void Start()
    {
        pos = transform.position; // Take the current position
    }
    void FixedUpdate()
    {
        //check for colliders in the way
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, 1);
        RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, 1);
        RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1);

        //movement
        if (Input.GetKey(KeyCode.A) && transform.position == pos && hitleft.collider == null)
        {
            pos += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) && transform.position == pos && hitright.collider == null)
        {           
            pos += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W) && transform.position == pos && hitup.collider == null)
		{           
            pos += Vector3.up; 
        }
        if (Input.GetKey(KeyCode.S) && transform.position == pos && hitdown.collider == null)
        {
            pos += Vector3.down;
        }

        if (Input.GetKey(KeyCode.LeftShift))//player sprinting?
        {
            sprint = true;
        }
        else
        {
            sprint = false;
        }

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
