using UnityEngine;

public class HeatLexeme :MagicLexeme
{
    public float addTemperature;
    public override void Execute(IMagicObject magicObject)
    {
        magicObject.AddTemperature(addTemperature);
    }
}
