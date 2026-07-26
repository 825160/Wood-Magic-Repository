using UnityEngine;

[CreateAssetMenu(fileName = "StraightLaunchLexeme", menuName = "Magic/Lexeme/4 Launch/StraightLaunchLexeme")]
public class StraightLaunchLexeme : MagicLexeme
{
    public float speed;
    public override void Execute(MagicContent content)
    {
        GameObject currMedium = content.currMedium;
        currMedium.transform.SetParent(null);
        StraightMovement sm = currMedium.AddComponent<StraightMovement>();

        sm.speed = speed;
        sm.direction = content.caster.forward;

        content.currMedium = null;
    }
}
