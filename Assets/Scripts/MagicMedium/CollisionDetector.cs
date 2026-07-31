using UnityEngine;
using MediumEnum;
using System;

public class CollisionDetector : MonoBehaviour
{
    private DamageModule damageModule;
    private MediumState mediumState;

    public event Action<GameObject> collisionEnemyEvent;

    private void Awake()
    {
        damageModule = GetComponent<DamageModule>();
        mediumState = GetComponent<Medium>().mediumState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && (mediumState.mediumStage == MediumStage.OnFly||mediumState.mediumStage == MediumStage.AfterCollion))
        {
            GetComponent<IMovementModule>()?.StopMove();
            Vector3 direction = transform.position - other.transform.position;
            damageModule.CaculateTotalDamage();
            other.gameObject.GetComponent<DamageReceiver>().ReceiveDamageByNum(damageModule.totalDamage, direction.normalized);
            collisionEnemyEvent?.Invoke(other.gameObject);
        }
    }
}
