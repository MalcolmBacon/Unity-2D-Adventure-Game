using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : PickupItemSpawn
{
    [SerializeField]
    GameObject closedChest;
    [SerializeField]
    GameObject openChest;
    [SerializeField]
    bool chestIsOpened;
    public Interactable interactable = new Interactable();
    public void Interact()
    {
        interactable.Interact(ref chestIsOpened, closedChest, openChest);
        if (chestIsOpened)
        {
            base.SpawnPickupItems();
        }
    }

}
