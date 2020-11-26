using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
    public string dialog;

    public override void Interact(Player character)
    {
        PopupSystem pop = GetComponent<PopupSystem>();
        pop.PopUp(dialog);
    }
}
