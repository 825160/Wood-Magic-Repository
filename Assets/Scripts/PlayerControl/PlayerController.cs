using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public InputAction jumpAction;
    public float moveSpeed = 5;
    public float turnSpeed = 20;

    private Rigidbody playerRb;
    private bool isOnGround = true;
    public float jumpForce = 100;

    public InputAction castAction;
    private CastMagicSpell cast;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        moveAction.Enable();
        jumpAction.Enable();
        castAction.Enable();
        cast = GetComponent<CastMagicSpell>();
        cast.isCastDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        //位移
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * moveInput.y);
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * moveInput.x);

        //判断跳跃
        if (jumpAction.triggered && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (castAction.triggered && cast.isCastDone)
        {
            StartCoroutine(cast.Cast());
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
