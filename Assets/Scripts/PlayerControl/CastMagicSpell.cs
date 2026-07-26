using System.Collections;
using UnityEngine;

public class CastMagicSpell : MonoBehaviour
{
    public MagicSpell spell;

    public bool isCastDone = true;

    public IEnumerator Cast()
    {
        isCastDone = false;
        MagicContent content = new MagicContent();
        content.caster = transform;

        foreach(MagicLexeme lexeme in spell.lexemes)
        {
            lexeme.Execute(content);
            yield return new WaitForSeconds(lexeme.castDelay);
        }
        isCastDone = true;
    }
}
