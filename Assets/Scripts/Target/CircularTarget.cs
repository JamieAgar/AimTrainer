using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Target
{
    public class CircularTarget : MonoBehaviour, ITarget
    {

        public int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private TargetManager targetManager;
        // Start is called before the first frame update
        void Start()
        {
            targetManager = FindObjectOfType<TargetManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TargetHit()
        {
            //TODO: Change this to events. Removes the link between the target and the targetManager
            targetManager.SpawnCircularTarget();
            Destroy(transform.parent.gameObject
                );
        }
    }
}