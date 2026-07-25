using UnityEngine;
using MediumEnum;
public class SolidMediumState
{
    public float currMass;
    public float currSpeed;

    public MediumShape currShape;

    public float currTemper;
    public bool burning;

    public float currSharpness;
    public float currHardness;

    public float PiercingNum;
    public SolidMediumState(SolidMediumData data)
    {
        currMass = data.initMass;
        currShape = data.initMediumShape;
        currTemper = data.initTemperature;
        currSharpness = data.initSharpness;
        currHardness = data.initHardness;

        burning = false;
        currSpeed = 0;
        CaculatePiercingNum();
    }

    public void CaculatePiercingNum()
    {
        PiercingNum = currSharpness * currMass * currSpeed * currHardness;
    }
}
