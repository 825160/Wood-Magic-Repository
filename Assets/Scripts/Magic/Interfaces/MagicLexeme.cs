using UnityEngine;

[CreateAssetMenu(fileName = "MagicLexeme", menuName = "Scriptable Objects/MagicLexeme")]
public abstract class MagicLexeme : ScriptableObject
{
    public string lexemeName;

    public float manaCost;

    public float castDelay;

    public abstract void Execute(IMagicObject magicObject);
}