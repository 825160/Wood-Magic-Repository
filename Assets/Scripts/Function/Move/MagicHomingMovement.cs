using System.Collections;
using UnityEngine;

public class MagicHomingMovement : StraightMovement
{
    [Header("追踪")]
    public Transform target;
    string targetTag = "Enemy";

    // 转向强度
    public float homingStrength = 3f;


    [Header("魔法弧度")]
    // 垂直方向初速度
    public float curveStrength = 30f;

    private Vector3 velocity;

    public override void Move()
    {

        if (target != null)
        {
            // 指向目标方向
            Vector3 targetDir =
                (target.position - transform.position)
                .normalized;



            // 魔法吸引力
            velocity =
                Vector3.Lerp(
                    velocity,
                    targetDir * speed,
                    homingStrength * Time.deltaTime
                );
        }

        // 移动
        transform.position +=
            velocity * Time.deltaTime ;

        speed += speed * Time.deltaTime;
        
        // 子弹朝向运动方向
        transform.forward = velocity.normalized;
    }

    public override void StartMove()
    {
        FindNearestTarget();
        Vector3 forward = transform.forward;


        // 随机产生一个垂直发射方向的向量
        Vector3 curveDirection =
            Vector3.Cross(
                forward,
                Random.onUnitSphere
            ).normalized;
        curveDirection.y = Mathf.Abs(curveDirection.y);

        // 初速度 = 正方向 + 侧向魔力
        velocity = curveDirection * curveStrength;

        base.StartMove();
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