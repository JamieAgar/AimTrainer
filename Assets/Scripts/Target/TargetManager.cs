using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Target
{
    public class TargetManager : MonoBehaviour
    {
        public ScoreSO scoreSO;

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
            scoreSO.numTargets.Value++;
            GameObject spawner = characterTargetSpawners[Random.Range(0, characterTargetSpawners.Length)];
            GameObject target = Instantiate(characterTargetPrefab, spawner.transform);
        }

        public void SpawnCircularTarget()
        {
            scoreSO.numTargets.Value++;
            GameObject spawner = circularTargetSpawners[Random.Range(0, circularTargetSpawners.Length)];
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = new Vector3(0, -90, 0);
            GameObject target = Instantiate(circularTargetPrefab, spawner.transform.position, rotation);
        }
    }
}