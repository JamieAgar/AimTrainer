using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScoreSO : ScriptableObject
{
    public IntVariable numTargets;
    public IntVariable numHeadshots;
    public IntVariable numBodyshots;
    public IntVariable numMimicMisses;
    public IntVariable numFives;
    public IntVariable numThrees;
    public IntVariable numOnes;
    public IntVariable numCircularMisses;

    //Scoring shouldn't be kept between sessions as this object is not a leaderboard
    public void OnEnable()
    {
        numTargets.Value = 0;
        numHeadshots.Value = 0;
        numBodyshots.Value = 0;
        numMimicMisses.Value = 0;
        numFives.Value = 0;
        numThrees.Value = 0;
        numOnes.Value = 0;
        numCircularMisses.Value = 0;
    }
}
