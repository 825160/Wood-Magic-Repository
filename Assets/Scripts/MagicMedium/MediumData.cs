using UnityEngine;
using MediumEnum;

[CreateAssetMenu(fileName = "NewMedium", menuName = "GameData/MediumData")]
public class MediumData : ScriptableObject
{
    //medium身份
    public int mediumID;
    public string mediumName;

    public MediumSort mediumSort;

    public MediumShape initMediumShape;


    //物理组件
    //初始质量
    public float initMass;

    //热量组件
    //是否可燃
    //public bool isBurnable;

    //燃点
    //public float burnPoint;

    //初始温度
    //public float initTemperature;


    //燃烧释放热量
    //public float burnReleaseEnergy;

    //刺穿组件
    //初始硬度
    public float initHardness;

    //初始锋利度
    public float initSharpness;


}
