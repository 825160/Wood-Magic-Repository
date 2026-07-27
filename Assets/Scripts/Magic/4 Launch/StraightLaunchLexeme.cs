using UnityEngine;

[CreateAssetMenu(fileName = "StraightLaunchLexeme", menuName = "Magic/Lexeme/4 Launch/StraightLaunchLexeme")]
public class StraightLaunchLexeme : LaunchLexeme
{
    public override void Execute(MagicContent content)
    {
        ExecuteMove<StraightMovement>(content);
    }
}
