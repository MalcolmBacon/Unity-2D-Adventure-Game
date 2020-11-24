using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Health Object", menuName="Health/HealthObject")]
public class HealthObject : ScriptableObject
{
    public string label;
    public float maxHealth;
}
