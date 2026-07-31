using UnityEngine;

public class Enemies : MonoBehaviour
{
    public EnemiesData enemiesData;

    public float currHealth;
    public bool isAlive;

    private Rigidbody rb;
    private GameObject player;
    public float stopDistance = 10f;
    public float enemySpeed = 3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        isAlive = false;
        currHealth = enemiesData.initHealth;


    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            float currDistance = Vector3.Distance(transform.position, player.transform.position);
            if (currDistance > stopDistance)
            {
                Vector3 currDirection = player.transform.position - transform.position;
                Vector3 targetPos = transform.position + currDirection * Time.fixedDeltaTime * enemySpeed;
                rb.MovePosition(targetPos);
            }
        }
    }
}
