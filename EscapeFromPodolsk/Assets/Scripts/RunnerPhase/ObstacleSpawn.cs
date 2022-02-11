using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();// добавляется в едиторе
    [SerializeField] private List<Transform> spawners = new List<Transform>(); // добавляется в едиторе
    private bool[] placeChec = new bool[10];
    void Start()
    {
         SetObstacles();
    }

    private void SetObstacles()
    {
        int curObsCount = 0;
        int maxObsCount = Random.Range(3, 7);

        while(maxObsCount > curObsCount)
        {
            int spawnerCount = Random.Range(0, spawners.Count);
            if (!placeChec[spawnerCount])
            {
                placeChec[spawnerCount] = true;
                Transform tempSpawnerTransf = spawners[spawnerCount];
                Instantiate(obstacles[Random.Range(0, obstacles.Count)], tempSpawnerTransf);
                curObsCount++;
            }
        }
    }
}
