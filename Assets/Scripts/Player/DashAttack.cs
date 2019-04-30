using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : PhysicsObject
{
    public float dashSpeed;
    public float startDashTime;

    private float dashTime;
    private float direction = Input.GetAxis("Horizontal");
    private bool dash = Input.GetButtonDown("Fire1");

    private void Start()
    {
        dashTime = startDashTime;
    }

    protected override void ComputeVelocity()
    {
        if (direction != 0)
        {
            if (dashTime <= 0)
            {
                dashTime = startDashTime;
            }
            else
            {
                dashTime -=Time.deltaTime;

                if (direction < 0 && dash)
                {
                    velocity = Vector2.left * dashSpeed;
                }
                else if (direction > 0 && dash)
                {
                    velocity = Vector2.right * dashSpeed;
                }
            }
        }
    }

}
