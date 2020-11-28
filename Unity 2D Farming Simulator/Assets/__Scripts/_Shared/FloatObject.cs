using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float Object", menuName = "Miscellaneous/Float Object")]
public class FloatObject : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;
    [HideInInspector]
    public float runTimeValue;
    [HideInInspector]
    public float maxRunTimeValue;

    public void OnAfterDeserialize()
    {
        //After unload
        runTimeValue = initialValue;
        maxRunTimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {
        //Start game
    }
}
