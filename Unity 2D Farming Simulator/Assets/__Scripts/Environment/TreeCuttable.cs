using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : PickupItem
{
    public void CutDownTree()
    {
        base.SpawnPickupItems();
        gameObject.SetActive(false);
    }
}
