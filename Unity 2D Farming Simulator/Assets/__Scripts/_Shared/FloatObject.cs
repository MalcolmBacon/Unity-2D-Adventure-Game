using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float Object", menuName = "Miscellaneous/Float Object")]
public class FloatObject : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;
    [HideInInspector]
    public float runTimeValue;

    public void OnAfterDeserialize()
    {
        //After unload
        runTimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {
        //Start game
    }
}
