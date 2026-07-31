using MediumEnum;
using UnityEngine;

public class MediumState
{
    public float currMass;
    public float currSpeed;

    public MediumShape currShape;

   // public float currTemper;
    //public bool burning;

    public float currSharpness;
    public float currHardness;

    public float PiercingNum;

    public MediumStage mediumStage;

    public SpinState spinState;
    public int spinHitEnemyNum;
    public MediumState(MediumData data)
    {
        currMass = data.initMass;
        currShape = data.initMediumShape;
        //currTemper = data.initTemperature;
        currSharpness = data.initSharpness;
        currHardness = data.initHardness;

        spinState = SpinState.None;
        //burning = false;
        currSpeed = 0;
        mediumStage = MediumStage.Design;

        spinHitEnemyNum = 4;
    }


}
