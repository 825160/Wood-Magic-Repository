using UnityEngine;

public class SolidMedium : MonoBehaviour, IMagicObject
{
    public SolidMediumData data;

    public SolidMediumState state;

    void IMagicObject.AddTemperature(float addTemperature)
    {
        state.currTemper += addTemperature;
    }

}
