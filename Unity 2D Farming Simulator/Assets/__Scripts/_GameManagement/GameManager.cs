using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        itemDatabase.UpdateDatabase();
    }
    public GameObject player;
    public InventoryObject playerInventory;
    public ItemDatabaseObject itemDatabase;
    public bool clearInventoryOnQuit = false;
    private void OnApplicationQuit()
    {
        if (clearInventoryOnQuit)
        {
            playerInventory.Container.Items.Clear();
        }
    }
}
