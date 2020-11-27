using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool canInteractWith { get; set; }
    void Interact(PopupSystem pop, string dialog);
    void Interact(ref bool chestIsOpened, GameObject closedChest, GameObject openChest);
    void Interact(string dialogue);
}
