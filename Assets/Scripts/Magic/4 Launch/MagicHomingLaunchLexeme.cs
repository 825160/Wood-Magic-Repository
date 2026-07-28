using UnityEngine;

[CreateAssetMenu(fileName = "MagicHomingLaunchLexeme", menuName = "Magic/Lexeme/4 Launch/MagicHomingLaunchLexeme")]
public class MagicHomingLaunchLexeme : LaunchLexeme
{
    public override void Execute(MagicContent content)
    {
        ExecuteMove<MagicHomingMovement>(content);
    }
}
