using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTarget : MonoBehaviour, Target
{ 
    public void TargetHit()
    {
        CharacterTarget ct = this.gameObject.GetComponentInParent<CharacterTarget>();
        ct.TargetHit();
        Debug.Log("Head Hit!");
    }
}
