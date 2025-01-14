using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;
    public bool isHoldingJump = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHoldingJump = false;
            
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        //Time.fixedDeltaTime locked framerate, want our jumps to always look the same.
        if (!isGrounded)
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }
        }

        transform.position = pos;
    }

}
