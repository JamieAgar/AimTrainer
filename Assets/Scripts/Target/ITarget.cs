using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Target
{
    public interface ITarget
    {
        //TODO: Add some kind of event so we can track accuracy%, headshot%. Maybe take in just an int for score?
        //Maybe need seperate events for headshot, bodyshot, despawned target, and maybe seperate ones for inner/outer versions
        //for the circular target.

        int Score
        {
            get;
            set;
        }

        public void TargetHit()
        {

        }
    }
}