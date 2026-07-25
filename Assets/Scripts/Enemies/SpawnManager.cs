using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemiesPrefab;
    private Stack<GameObject> enemiesPool;
    private int maxSpawnNum = 50;

    public float spawnRate = 1f;

    public float spawnMaxRange = 40f;
    public float spawnMinRange = 30f;

    void Start()
    {
        for(int i = 0; i < maxSpawnNum; i++)
        {
            GameObject obj = Instantiate(enemiesPrefab);
            obj.SetActive(false);
            enemiesPool.Push(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GetSpawnPos()
    {
        return new Vector3(GetRandomXPos(), 2, GetRandomXPos());
    }

    private float GetRandomXPos()
    {
        int i = Random.Range(0, 2);
        if(i == 0)
        {
            return Random.Range(spawnMinRange, spawnMaxRange);
        }
        return -Random.Range(spawnMinRange, spawnMaxRange);
    }
}
