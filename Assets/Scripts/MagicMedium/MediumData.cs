using UnityEngine;
using MediumEnum;
public class MediumData : ScriptableObject
{
    //medium身份
    public int mediumID;
    public string mediumName;

    public MediumSort mediumSort;

    public MediumShape initMediumShape;

    public float initTemperature;
}
