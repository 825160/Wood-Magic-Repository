using Unity.VisualScripting;
using UnityEngine;

public class GroundReflect : MonoBehaviour
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Vector3 velocity = rb.linearVelocity;

            velocity.y = 5f;

            rb.linearVelocity = velocity;
        }
    }
}