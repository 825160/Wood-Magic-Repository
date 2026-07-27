using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    private Enemies enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemies>();
    }

    public void ReceiveDamageByNum(float damage,Vector3 direction)
    {
        if(enemy.currHealth < damage)
        {
            Die();
        }

        enemy.currHealth -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
