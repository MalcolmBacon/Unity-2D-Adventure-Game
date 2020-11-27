using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : IInteractable
{
    public bool canInteractWith { get; set; }
    public Interactable()
    {
        canInteractWith = true;
    }

    public void Interact(PopupSystem pop, string dialog)
    {
        pop.PopUp(dialog);
    }
    public void Interact(ref bool chestIsOpened, GameObject closedChest, GameObject openChest)
    {
        if (!chestIsOpened)
        {
            canInteractWith = false;
            chestIsOpened = true;
            closedChest.SetActive(false);
            openChest.SetActive(true);
        }
    }

    public void Interact(string dialogue)
    {
        Debug.Log(dialogue);
    }
}
