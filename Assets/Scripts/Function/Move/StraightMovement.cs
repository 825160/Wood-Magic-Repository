using UnityEngine;

public class StraightMovement : MovementModule
{
    public float speed = 20f;

    public Vector3 direction;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        rb.linearVelocity = direction * speed;
    }
}
