using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float turnSpeed = 20f;
    private float turnMaxAngle = 90;
    private int turnMode = 0;
    private float currAngle = 90;
    private Vector3 currPirot;
    private Vector3[] directions = new Vector3[]
{
    Vector3.forward,
    Vector3.back,
    Vector3.up,
    Vector3.down,
    Vector3.right,
    Vector3.left
};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currAngle>=turnMaxAngle)
        {
            turnMode = Random.Range(0, 6);
            currPirot = directions[turnMode];
            currAngle = 0;
        }
        transform.Rotate(currPirot, turnSpeed * Time.deltaTime);
        currAngle += turnSpeed * Time.deltaTime;
    }
}
