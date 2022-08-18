using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Target
{
    public class TargetManager : MonoBehaviour
    {
        public float targetSpeed = 12f;
        public TargetSettingsSO targetSettingsSO;

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
            SpawnCircularTarget();
        }

        public void SpawnCharacterTarget()
        {
            GameObject spawner = characterTargetSpawners[Random.Range(0, characterTargetSpawners.Length)];
            GameObject target = Instantiate(characterTargetPrefab, spawner.transform);
            targetSettingsSO.mimicSpeed.Value = targetSpeed;
        }

        public void SpawnCircularTarget()
        {
            GameObject spawner = circularTargetSpawners[Random.Range(0, circularTargetSpawners.Length)];
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = new Vector3(0, -90, 0);
            GameObject target = Instantiate(circularTargetPrefab, spawner.transform.position, rotation);
        }
    }
}