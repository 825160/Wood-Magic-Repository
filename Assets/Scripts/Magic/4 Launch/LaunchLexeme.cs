using UnityEngine;

public class LaunchLexeme : MagicLexeme
{
    public float speed;

    public float speedForDamage;

    public void ExecuteMove<T>(MagicContent content)
        where T: MonoBehaviour, IMovementModule
    {
        GameObject currMedium = content.currMedium;
        currMedium.transform.SetParent(null);
        T sm = currMedium.AddComponent<T>();
        currMedium.GetComponent<Medium>().mediumState.currSpeed = speedForDamage;
        sm.StartMove();

        sm.InitMovement(content.caster.forward, speed);

        content.currMedium = null;
    }

    public override void Execute(MagicContent content)
    {
        
    }

}
