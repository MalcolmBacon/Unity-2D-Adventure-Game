using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(InventoryObject))]
public class ItemContainerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // InventoryObject container = target as InventoryObject;
        // if (GUILayout.Button("Reset Inventory List"))
        // {
        //     container.Container.Clear();
        // }
        // if (GUILayout.Button("Reset Inventory List Items"))
        // {
        //     for (int i = 0; i < container.Container.Count; i++)
        //     {
        //         container.Container[i].item = null;
        //         container.Container[i].amount = 0;
        //     }
        // }
        DrawDefaultInspector();
    }
}
