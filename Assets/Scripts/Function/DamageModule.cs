using UnityEngine;

public class DamageModule : MonoBehaviour
{
    public float totalDamage;
    private MediumState mediumState;
    void Start()
    {
        totalDamage = 0;
        mediumState = GetComponent<Medium>().mediumState;
    }

    public void CaculateTotalDamage()
    {
        totalDamage = GetCollisionDamage() + GetPierceDamage();
    }

    public float GetCollisionDamage()
    {
        return mediumState.currSpeed * mediumState.currMass * mediumState.currHardness;
    }

    public float GetPierceDamage()
    {
        return GetCollisionDamage() * mediumState.currSharpness;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
