using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesData", menuName = "Scriptable Objects/EnemiesData")]
public class EnemiesData : ScriptableObject
{
    public int enemiesIndex;

    public string enemiesName;

    public float initHealth;
}
