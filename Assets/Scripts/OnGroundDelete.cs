using UnityEngine;

public class OnGroundDelete : MonoBehaviour
{
    private bool isOnGround = false;
    private float currTime = 0;
    public float stopRotateTime = 2;
    public float delayTime = 5;
    Skill_FastRotate fastRotate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fastRotate = GetComponent<Skill_FastRotate>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround)
        {
            currTime += Time.deltaTime;
        }
        if (currTime > stopRotateTime&&fastRotate!=null)
        {
            fastRotate.enabled = false;
        }
        if (currTime > delayTime)
        {
            Destroy(gameObject);
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
