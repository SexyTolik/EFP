using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    [SerializeField] private GameObject worldPrefab;
    private List<GameObject> partsOfWorld = new List<GameObject>();
    [SerializeField] private float speed = 0f;
    [SerializeField] private int maxPartCount = 6;
    [SerializeField] private int partSize;
    void Start()
    {
        StartGeneration();
        partsOfWorld[0].GetComponent<ObstacleSpawn>().enabled = false;
    }

    void Update()
    {
        foreach(GameObject wParts in partsOfWorld)
        {
            wParts.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        }
        if (partsOfWorld[0].transform.position.z < -partSize)
        {
            Destroy(partsOfWorld[0]);
            partsOfWorld.RemoveAt(0);
            GenerateNextPart();
        }
    }

    void GenerateNextPart()
    {
        Vector3 pos = Vector3.zero;
        if(partsOfWorld.Count > 0) { pos = partsOfWorld[partsOfWorld.Count - 1].transform.position + new Vector3(0, 0, partSize); }
        GameObject temp = Instantiate(worldPrefab, pos, Quaternion.identity);
        temp.transform.SetParent(transform);
        partsOfWorld.Add(temp);
    }
    void StartGeneration()
    {
        while (partsOfWorld.Count > 0)
        {
            Destroy(partsOfWorld[0]);
            partsOfWorld.RemoveAt(0);
        }
        for (int i = 0; i < maxPartCount; i++)
        {
            GenerateNextPart();
        }
    }
}
