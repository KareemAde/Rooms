using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFinal : PhysicsObject
{
    public float maxSpeed = 15;
    public float jumpTakeOffSpeed = 35f;

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
                velocity.y = velocity.y * 0.5f;
        }

        if (move.x < 0.0f && Input.GetButtonDown("Fire1")) 
        {
            move = Vector2.left * 50;
        }
        else if (move.x > 0.0f && Input.GetButtonDown("Fire1"))
        {
            move = Vector2.right * 50;
        }

        targetVelocity = move * maxSpeed;
    }

  
}
