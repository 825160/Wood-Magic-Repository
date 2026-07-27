using UnityEngine;

public interface IMovementModule 
{
    public void Move();
    public void StartMove();
    public void StopMove();

    public void InitMovement(Vector3 direction, float speed);

}
