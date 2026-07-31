using System.Collections.Generic;
using UnityEngine;
using MediumEnum;
using Unity.VisualScripting;

public class SpinHitEnemyTrack : MonoBehaviour
{
    private Transform target;

    private MediumState mediumState;

    public List<GameObject> Enemies;

    private float speed;

    private CollisionDetector detector;

    private void Awake()
    {
        mediumState = GetComponent<Medium>().mediumState;
        detector = GetComponent<CollisionDetector>();
        Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        speed = 20f;
    }

    private void OnEnable()
    {
        detector.collisionEnemyEvent += OnHitEnemy;
    }

    private void OnDisable()
    {
        detector.collisionEnemyEvent -= OnHitEnemy;
    }

    private void OnHitEnemy(GameObject enemy)
    {
        if (mediumState.spinHitEnemyNum == 0)
        {
            Destroy(this);
            return;
        }
        mediumState.spinHitEnemyNum--;
        Enemies.Remove(enemy);
        FindEnemy();
    }



    private void Update()
    {
        if (target != null) { 
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void FindEnemy()
    {
        target = null;
        float minDotProduct = Mathf.Infinity;
        Vector2 spinAxis = Vector2.zero;
        switch (mediumState.spinState)
        {
            case SpinState.Forward:
                spinAxis = GetHorizontalPosition(transform.forward);
                break;
            case SpinState.Side:
                spinAxis = GetHorizontalPosition(transform.right);
                break;
        }
        spinAxis.Normalize();
        foreach (var enemy in Enemies)
        {
            Vector2 bulletToEnemyHorizontalVector = GetHorizontalPosition(enemy.transform.position) - GetHorizontalPosition(transform.position);
            bulletToEnemyHorizontalVector.Normalize();
            float currDotProduct = Vector2.Dot(bulletToEnemyHorizontalVector, spinAxis);
            if (currDotProduct < minDotProduct)
            {
                target = enemy.transform;
                minDotProduct = currDotProduct;
            }
        }
    }

    private Vector2 GetHorizontalPosition(Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }
}
