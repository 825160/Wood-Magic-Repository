using UnityEngine;

[CreateAssetMenu(fileName = "ParabolaLaunchLexeme", menuName = "Magic/Lexeme/4 Launch/ParabolaLaunchLexeme")]
public class ParabolaLaunchLexeme : LaunchLexeme
{
    public override void Execute(MagicContent content)
    {
        content.currMedium.AddComponent<GroundReflect>();
        ExecuteMove<ParabolaMovement>(content);
    }
}
