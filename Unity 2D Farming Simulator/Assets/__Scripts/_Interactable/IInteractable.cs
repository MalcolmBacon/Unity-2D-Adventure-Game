using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    bool canInteractWith { get; set; }
    void Interact(string dialogue);
    void Interact(GameObject panel);
    void Interact(PopupSystem pop, string dialog);
    void Interact(ref bool chestIsOpened, GameObject closedChest, GameObject openChest);
}
