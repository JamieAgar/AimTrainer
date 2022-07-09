using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    public GameObject characterTargetPrefab;
    private GameObject[] targetSpawners;

    // Start is called before the first frame update
    void Start()
    {
        targetSpawners = GameObject.FindGameObjectsWithTag("TargetSpawner");
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        GameObject spawner = GetSpawner();
        Instantiate(characterTargetPrefab, spawner.transform);
    }

    GameObject GetSpawner()
    {
        return targetSpawners[Random.Range(0, targetSpawners.Length)];
    }
}
