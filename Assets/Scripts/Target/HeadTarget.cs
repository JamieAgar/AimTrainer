using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Target
{
    public class HeadTarget : MonoBehaviour, ITarget
    {
        public int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public void TargetHit()
        {
            MimicTarget mt = gameObject.GetComponentInParent<MimicTarget>();
            mt.HeadHit();
        }
    }
}