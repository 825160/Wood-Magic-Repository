using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(
    fileName = "SpawnWood",
    menuName = "Magic/Lexeme/1 Acquire/SpawnWood"
)]
public class SpawnWoodLexeme : MagicLexeme
{
    public GameObject woodPrefab;

    public override void Execute(MagicContent content)
    {
        GameObject wood = Instantiate(woodPrefab, content.caster.position + content.caster.forward * 2 + content.caster.up, content.caster.rotation, content.caster);
        content.currMedium = wood;
    }
}
