using UnityEngine;
using MediumEnum;

public class CollisionDetector : MonoBehaviour
{
    private DamageModule damageModule;
    private MediumState mediumState;


    private void Awake()
    {
        damageModule = GetComponent<DamageModule>();
        mediumState = GetComponent<Medium>().mediumState;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && mediumState.mediumStage == MediumStage.OnFly)
        {
            GetComponent<IMovementModule>().StopMove();
            Vector3 direction = transform.position - collision.transform.position;
            damageModule.CaculateTotalDamage();
            collision.gameObject.GetComponent<DamageReceiver>().ReceiveDamageByNum(damageModule.totalDamage, direction.normalized);
        }
    }
}
