using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject player;
    public InventoryObject playerInventory;
    public bool clearInventoryOnQuit = false;
    private void OnApplicationQuit()
    {
        if (clearInventoryOnQuit)
        {
            playerInventory.Container.Clear();
        }
    }
}
