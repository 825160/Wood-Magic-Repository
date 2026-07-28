using UnityEngine;
using UnityEngine.InputSystem;


public class CameraLook : MonoBehaviour
{

    public Transform cameraTransform;


    public float sensitivity = 0.1f;


    private Vector2 lookInput;


    private float cameraRotationX;



    // Input System 自动调用
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }



    void Update()
    {

        float mouseX =
            lookInput.x * sensitivity;


        float mouseY =
            lookInput.y * sensitivity;



        // 摄像机上下
        cameraRotationX -= mouseY;


        cameraRotationX =
            Mathf.Clamp(
                cameraRotationX,
                -90f,
                90f
            );


        cameraTransform.localRotation =
            Quaternion.Euler(
                cameraRotationX,
                0,
                0
            );



        // 玩家左右

        transform.Rotate(
            Vector3.up *
            mouseX
        );

    }



    void Start()
    {
        Cursor.lockState =
            CursorLockMode.Locked;

        Cursor.visible = false;
    }

}