using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
public class ItemDatabaseObject : ScriptableObject//, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    //public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();
    public Dictionary<string, ItemObject> GetItem = new Dictionary<string, ItemObject>();

    [ContextMenu("Update Database")]
    public void UpdateDatabase()
    {
        GetItem = new Dictionary<string, ItemObject>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetItem.Add(Items[i].ID, Items[i]);
        }
    }
    // public void OnAfterDeserialize()
    // {
    //     Debug.Log("In on after deserialize");
    //     for (int i = 0; i < Items.Length; i++)
    //     {
    //         // Debug.Log(Items[i].ID);
    //         // Debug.Log(Items[i].uiDisplay);
    //         // Debug.Log(Items[i].type);
    //         // Debug.Log(Items[i].description);

    //         //Items[i].Id = i; //set item ids
    //        // GetItem.Add(i, Items[i]);
    //         GetItem.Add(Items[i].ID, Items[i]);
    //     }
    // }

    // public void OnBeforeSerialize()
    // {
    //     //Clear items out before serializing 
    //     //GetItem = new Dictionary<int, ItemObject>();
    //     GetItem = new Dictionary<string, ItemObject>();

    // }
}
