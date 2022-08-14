using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public float targetSpeed = 12f;

    public GameObject characterTargetPrefab;
    public GameObject circularTargetPrefab;
    private GameObject[] characterTargetSpawners;
    private GameObject[] circularTargetSpawners;

    // Start is called before the first frame update
    void Start()
    {
        characterTargetSpawners = GameObject.FindGameObjectsWithTag("CharacterTargetSpawner");
        circularTargetSpawners = GameObject.FindGameObjectsWithTag("CircularTargetSpawner");
        SpawnCharacterTarget();
    }

    public void SpawnCharacterTarget()
    {
        GameObject spawner = GetSpawner();
        GameObject target = Instantiate(characterTargetPrefab, spawner.transform);
        target.GetComponent<CharacterTarget>().moveSpeed = targetSpeed;
    }

    GameObject GetSpawner()
    {
        return characterTargetSpawners[Random.Range(0, characterTargetSpawners.Length)];
    }
}
