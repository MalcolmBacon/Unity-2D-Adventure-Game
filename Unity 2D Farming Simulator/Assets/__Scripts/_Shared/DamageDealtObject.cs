using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Dealt Database", menuName = "Combat System/Damage Dealt")]
public class DamageDealtObject : ScriptableObject
{
    public float forceOfKnockback;
    public float knockbackTime;
    public float damage;
}
