using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Target
{
    public class CircularTarget : MonoBehaviour, ITarget
    {
        //Determine the direction the target should move so the targets are always moving towards the center
        private Vector3 direction = Vector3.zero;
        private float targetZ = -12f;

        public ScoreSO scoreSO;
        public TargetSettingsSO targetSettingsSO;

        public int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private TargetManager targetManager;
        void Start()
        {
            targetManager = FindObjectOfType<TargetManager>();

            //Set direction to -12f
            direction.z = transform.position.z < targetZ ? 1f : -1f;
        }

        float despawnTimer = 0f;
        void Update()
        {
            //Despawn the target after some time
            despawnTimer += Time.deltaTime;
            if (despawnTimer > targetSettingsSO.despawnTime.Value)
            {
                //Debug.Log("Target Despawned");
                TargetMiss();
            }

            //Move the target 
            transform.parent.Translate(direction * Time.deltaTime, Space.World);
        }
        
        public void TargetHit()
        {
            //TODO: Change this to events. Removes the link between the target and the targetManager
            targetManager.SpawnCircularTarget();
            switch(score)
            {
                case 5:
                    scoreSO.numFives.Value++;
                    break;
                case 3:
                    scoreSO.numThrees.Value++;
                    break;
                default:
                    scoreSO.numOnes.Value++;
                    break;
            }
            Destroy(transform.parent.gameObject);
        }
        public void TargetMiss()
        {
            targetManager.SpawnCircularTarget();
            scoreSO.numCircularMisses.Value++;
            Destroy(transform.parent.gameObject);
        }
    }
}