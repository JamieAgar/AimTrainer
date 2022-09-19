using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TargetSettingsSO : ScriptableObject
{
    public FloatVariable targetSpeed;
    public FloatVariable despawnTime;
    public FloatVariable minChangeTime;
    public FloatVariable maxChangeTime;
}
