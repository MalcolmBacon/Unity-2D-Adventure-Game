using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : PickupItemSpawn
{
    public void CutDownTree()
    {
        base.SpawnPickupItems();
        gameObject.SetActive(false);
    }
}
