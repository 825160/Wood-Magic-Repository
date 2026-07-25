using UnityEngine;

public class Skill_FastRotate : MonoBehaviour
{
    public float turnSpeed = 80;
    Transform parentTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AutoRotate autoRotate = GetComponent<AutoRotate>();
        parentTransform = transform.parent;
        if (autoRotate != null)
        {
            autoRotate.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(parentTransform.forward, turnSpeed * Time.deltaTime, Space.World);
    }

}
