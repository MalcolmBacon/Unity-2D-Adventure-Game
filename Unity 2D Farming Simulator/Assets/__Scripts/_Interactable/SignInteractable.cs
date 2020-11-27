using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignInteractable : MonoBehaviour
{
    public string dialog;
    private PopupSystem pop;
    public Interactable interactable = new Interactable();

    public bool canInteractWith { get; set; }

    public void Interact()
    {
        pop = GetComponent<PopupSystem>();
        interactable.Interact(pop, dialog);
    }
}
