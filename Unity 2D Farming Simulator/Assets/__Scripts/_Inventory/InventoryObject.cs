﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    private string savePath = "/inventory.Save";
    public ItemDatabaseObject database;
    public Inventory Container;
    public void AddItem(ItemObject itemObject, int amount)
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].item.ID == itemObject.ID)
            {
                Container.Items[i].AddAmount(amount);
                return;
            }
        }
        Container.Items.Add(new InventorySlot(itemObject.ID, new Item(itemObject), amount));
    }
    public void SellItem(ItemObject itemForSale, string currencyID)
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].item.ID == itemForSale.ID)
            {
                if (Container.Items[i].DecrementAmount())
                {
                    AddItem(database.GetItem[currencyID], itemForSale.value);
                    return;
                }
            }
        }
    }
    public bool BuyItem(ItemObject itemToBuy, string currencyID)
    {
        //Eventually need to switch stackable logic to AddItem() function and change ID logic
        if (!itemToBuy.stackable)
        {
            if (Container.Items.Any(x => x.ID == itemToBuy.ID))
            {
                return false;
            }
        }

        for (int i = 0; i < Container.Items.Count; i++)
        {
            if (Container.Items[i].item.ID == currencyID) //Get gold in inventory
            {
                InventorySlot coins = Container.Items[i];
                if (coins.DecreaseAmount(itemToBuy.value)) //Buy item if have enough
                {
                    AddItem(itemToBuy, 1);
                    return true;
                }
            }
        }
        return false;
    }


    [ContextMenu("Save")]
    public void Save()
    {
        SaveWithJsonUtility();
    }
    private void SaveWithJsonUtility()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath)))
        {
            bf.Serialize(file, saveData);
        }
    }
    private void SaveWithIFormatter()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write))
        {
            formatter.Serialize(stream, Container);
        }
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            LoadWithJson();
        }
    }
    private void LoadWithJson()
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open))
        {
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
        }
    }
    private void LoadWithIFormatter()
    {
        IFormatter formatter = new BinaryFormatter();
        using (Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read))
        {
            Container = (Inventory)formatter.Deserialize(stream);
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new Inventory();
    }
}
[System.Serializable]
public class Inventory
{
    public List<InventorySlot> Items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public string ID;
    public Item item;
    public int amount;
    public InventorySlot(string _ID, Item _item, int _amount)
    {
        ID = _ID;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public bool DecrementAmount()
    {
        if (amount > 0)
        {
            amount--;
            return true;
        }
        return false;
    }
    public bool DecreaseAmount(int value)
    {
        if (amount >= value)
        {
            amount -= value;
            return true;
        }
        return false;
    }
}
