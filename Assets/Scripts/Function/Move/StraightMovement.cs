using UnityEngine;
using MediumEnum;
public class StraightMovement : MonoBehaviour, IMovementModule
{
    public float speed = 20f;

    protected Vector3 direction;
    protected Rigidbody rb;

    protected MediumState state;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        state = GetComponent<Medium>().mediumState;
    }

    private void FixedUpdate()
    {
        if (state.mediumStage == MediumStage.OnFly) 
        { 
            Move(); 
        }
    }

    public virtual void Move()
    {
        rb.linearVelocity = direction * speed;
    }
    public virtual void StartMove() 
    {
        state.mediumStage = MediumStage.OnFly;
    }

    public virtual void StopMove()
    {
        state.mediumStage = MediumStage.AfterCollion;
        rb.linearVelocity = Vector3.zero;
        Destroy(this);
    }

    public void InitMovement(Vector3 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
    }
}
