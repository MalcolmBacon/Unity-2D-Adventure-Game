using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : Interactable
{
    Interactable interactable = new Interactable();
    public void Interact()
    {
        interactable.Interact("Dialogue");
    }
}
