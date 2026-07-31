using UnityEngine;
using MediumEnum;

public class SpinModule : MonoBehaviour
{
    private Vector3 spinAxis;

    private float spinSpeed;

    private MediumState state;

    private void Awake()
    {
        state = GetComponent<Medium>().mediumState;
        spinSpeed = 400f;
        StartSpin(SpinState.Forward);
    }

    public void StartSpin(SpinState spinState)
    {
        state.spinState = spinState;
        switch (spinState)
        {
            case SpinState.Side:
                spinAxis = Vector3.up;
                break;
            case SpinState.Forward:
                spinAxis = transform.right;
                break;
        }
    }

    private void Update()
    {
        transform.Rotate(spinAxis, spinSpeed * Time.deltaTime);
    }
}
