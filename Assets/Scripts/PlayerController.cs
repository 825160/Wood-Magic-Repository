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

    public InputAction spawnWoodAction;
    public GameObject woodPrefab;
    public int maxSpawnWoodNum = 1;
    public int currSpawnWoodNum = 0;
    private float spawnWoodOffset = 2;
    private GameObject currWood;

    public InputAction lauchAction;
    public float lauchPower = 20;

    public InputAction skillOneAction;

    public GameObject coneSpawnWoodPrefab;
    public InputAction skillTwoAction;

    public InputAction skillThreeACtion;
    public float smallScaleRatio = 1.414f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        moveAction.Enable();
        jumpAction.Enable();
        spawnWoodAction.Enable();
        lauchAction.Enable();
        skillOneAction.Enable();
        skillTwoAction.Enable();
        skillThreeACtion.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //位移
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * moveInput.y);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);

        //判断跳跃
        if (jumpAction.triggered && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        //生成木块
        if (spawnWoodAction.triggered && currSpawnWoodNum < maxSpawnWoodNum)
        {
            currWood = Instantiate(woodPrefab, transform.position + transform.forward * spawnWoodOffset, transform.rotation,transform);
            Rigidbody rb = currWood.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            currSpawnWoodNum++;
        }

        //发射物块
        if (lauchAction.triggered && IsHaveWood())
        {
            currWood.transform.SetParent(null);
            AutoRotate autoRotate = currWood.GetComponent<AutoRotate>();
            if (autoRotate != null)
            {
                autoRotate.enabled = false;
            }
            Rigidbody rb = currWood.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(transform.forward * lauchPower, ForceMode.Impulse);
            currSpawnWoodNum--;
            currWood = null;
        }

        //技能 旋转物块
        if (skillOneAction.triggered && IsHaveWood())
        {
            Skill_FastRotate fastRotate = currWood.GetComponent<Skill_FastRotate>();
            fastRotate.enabled = true;
        }

        if(skillTwoAction.triggered&& IsHaveWood())
        {
            Destroy(currWood);
            currWood = Instantiate(coneSpawnWoodPrefab, 
                transform.position + transform.forward * spawnWoodOffset,
                transform.rotation * Quaternion.Euler(90, 0, 0), 
                transform);
            Rigidbody rb = currWood.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            currSpawnWoodNum++;
        }

        if (skillThreeACtion.triggered && IsHaveWood()) {
            Vector3 prevLocalScale = currWood.transform.localScale;
            currWood.transform.localScale = new Vector3(prevLocalScale.x / smallScaleRatio, prevLocalScale.y* smallScaleRatio * smallScaleRatio, prevLocalScale.z / smallScaleRatio);
        }
    }

    private bool IsHaveWood()
    {
        return currSpawnWoodNum > 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
