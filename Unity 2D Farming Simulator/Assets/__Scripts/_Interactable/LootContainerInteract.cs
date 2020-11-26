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
        if (!chestIsOpened)
        {
            canInteractWith = false;
            chestIsOpened = true;
            closedChest.SetActive(false);
            openChest.SetActive(true);
        }
    }

}
