using UnityEngine;

public class ParabolaMovement : StraightMovement
{
   public override void Move()
    {
        rb.linearVelocity = direction * speed;
        rb.linearVelocity += Physics.gravity * Time.fixedDeltaTime * 5;
        if (rb.linearVelocity.y < -20f)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, -20f, rb.linearVelocity.z);
        }
    }
}

