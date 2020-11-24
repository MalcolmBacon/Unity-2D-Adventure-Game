using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    private string savePath = "/inventory.Save";
    private ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable() {
        //make sure json utility does not override variable
        #if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
        #else
        database = Resources.Load<ItemDatabaseObject>("Database");
        #endif
    }
    public void AddItem(ItemObject item, int amount)
    {
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == item)
            {
                Container[i].AddAmount(amount);
                return;
            }
        }
        Container.Add(new InventorySlot(database.GetId[item], item, amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath)))
        {
            Debug.Log("Save inventory inventory");
            Debug.Log(saveData);
            bf.Serialize(file, saveData);
        }
    }
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            Debug.Log("Load inventory");
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open))
            {
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            }
        }
    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.GetItem[Container[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public ItemObject item;
    public int amount;
    public InventorySlot(int _ID, ItemObject _item, int _amount)
    {
        ID = _ID;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
