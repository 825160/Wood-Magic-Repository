using MediumEnum;
using UnityEngine;

public class ParabolaMovement : StraightMovement
{
    private Vector3 velocity;
    private float gravity;
    private void Start()
    {
        velocity = direction * speed;
        rb.useGravity = true;
        rb.linearVelocity = velocity;
    }

   public override void Move()
    {

    }

    public override void StopMove()
    {
        base.StopMove();
        Destroy(GetComponent<GroundReflect>());
    }
}

