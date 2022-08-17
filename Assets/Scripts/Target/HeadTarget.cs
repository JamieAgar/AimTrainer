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
            CharacterTarget ct = gameObject.GetComponentInParent<CharacterTarget>();
            ct.TargetHit();
            Debug.Log("Head Hit!");
        }
    }
}