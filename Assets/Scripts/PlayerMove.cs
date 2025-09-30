using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float xv, yv;
    bool isGrounded;
    public Animator anim;
    bool result;

    LayerMask groundLayerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // set the mask to be "Ground"
        groundLayerMask = LayerMask.GetMask("Ground");
    }
    void Update()
    {
        float xvel;
        float yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("d"))
        {
            xvel = 5;
        }

        if (Input.GetKey("a"))
        {
            xvel = -5;
        }


        if (Input.GetKeyDown(KeyCode.LeftAlt) || (Input.GetKeyDown(KeyCode.Space) && isGrounded))
        {
            yvel = 11;
            print("do jump");
        }

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        isGrounded = ExtendedRayCollisionCheck(0, 0);

        /*
        if ()
        {
            result = true;
        }
        else
        {
            result = false;
        }
        */

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //isGrounded = true;
        //print("isgrounded")
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //isGrounded = false;
    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;
    }
}
