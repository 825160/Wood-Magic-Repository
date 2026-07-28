using UnityEngine;

public class MagicBullet : MonoBehaviour
{
    [Header("追踪参数")]
    public string targetTag = "Enemy";
    public float speed = 20f;
    public float rotateSpeed = 180f;            // 转向速度（度/秒），越小弧度越大
    public float lifeTime = 5f;
    public float maxDistance = 50f;

    [Header("初始偏转（大弧度关键）")]
    public float initialSpreadAngle = 30f;      // 初始偏转角度（度），0=直线，越大弧线越夸张
    public bool randomDeviation = true;         // 是否随机方向，关闭则固定朝向一个方向（可手动设）


    private Transform target;
    private float spawnTime;
    private Vector3 velocity;                   // 当前速度方向（单位向量）
    private float spiralAngle;

    void Start()
    {
        spawnTime = Time.time;
        if (target == null) FindNearestTarget();

        // --- 初始化速度方向：在发射方向基础上增加偏转 ---
        Vector3 baseDir = transform.forward;
        if (initialSpreadAngle > 0)
        {
            // 1. 在垂直平面内随机一个方向
            Vector3 randomDir;
            if (randomDeviation)
            {
                // 随机单位向量，投影到垂直平面
                Vector3 rand = Random.onUnitSphere;
                randomDir = Vector3.ProjectOnPlane(rand, baseDir).normalized;
                if (randomDir.sqrMagnitude < 0.001f) // 极端情况
                    randomDir = transform.up;
            }
            else
            {
                // 固定偏转方向（例如向右），可外部赋值
                randomDir = transform.right; // 默认右侧
            }
            // 2. 绕 randomDir 轴旋转 baseDir 一定角度
            float angle = initialSpreadAngle * Mathf.Deg2Rad;
            velocity = Quaternion.AngleAxis(angle, randomDir) * baseDir;
        }
        else
        {
            velocity = baseDir;
        }
        velocity.Normalize();

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 生命周期检查（距离）
        if (Vector3.Distance(transform.position, Vector3.zero) > maxDistance)
        {
            Destroy(gameObject);
            return;
        }

        // 如果目标丢失或死亡，尝试重新寻找
        if (target == null)
        {
            FindNearestTarget();
            // 如果没有目标，继续直线飞行
            if (target == null)
            {
                transform.position += velocity * speed * Time.deltaTime;
                return;
            }
        }

        // --- 计算目标方向 ---
        Vector3 targetDir = (target.position - transform.position).normalized;

        // --- 转向（平滑曲线） ---
        // 使用 RotateTowards 让速度方向逐渐转向目标方向
        velocity = Vector3.RotateTowards(velocity, targetDir, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 0f);
        velocity.Normalize();
        Vector3 finalDir = velocity;

        // --- 移动 ---
        transform.position += finalDir * speed * Time.deltaTime;

        // --- 自旋（增加魔法感） ---
        transform.Rotate(Vector3.forward, 360f * Time.deltaTime); // 绕自身前轴旋转
    }

    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        float minDist = Mathf.Infinity;
        Transform nearest = null;
        foreach (var enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = enemy.transform;
            }
        }
        target = nearest;
    }

}
