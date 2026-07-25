using UnityEngine;
using MediumEnum;

[CreateAssetMenu(fileName = "NewSolidMedium", menuName = "GameData/SolidMediumData")]
public class SolidMediumData : MediumData
{
    //物理组件
    //初始质量
    public float initMass;

    //热量组件
    //是否可燃
    public bool isBurnable;

    //燃点
    public float burnPoint;


    //燃烧释放热量
    public float burnReleaseEnergy;

    //刺穿组件
    //初始硬度
    public float initHardness;

    //初始锋利度
    public float initSharpness;



#if UNITY_EDITOR
    private void Reset()
    {
        mediumSort = MediumSort.Solid;
        initTemperature = 20f;
        initMediumShape = MediumShape.Cube;

    }
#endif
}
