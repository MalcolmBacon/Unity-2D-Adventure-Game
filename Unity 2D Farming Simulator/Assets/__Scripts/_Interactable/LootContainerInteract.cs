using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField]
    GameObject closedChest;
    [SerializeField]
    GameObject openChest;
    [SerializeField]
    bool chestIsOpened;
    public override void Interact(Player character)
    {
        Debug.Log("In interact");
        if (!chestIsOpened)
        {
            chestIsOpened = true;
            closedChest.SetActive(false);
            openChest.SetActive(true);
        }
    }

}
