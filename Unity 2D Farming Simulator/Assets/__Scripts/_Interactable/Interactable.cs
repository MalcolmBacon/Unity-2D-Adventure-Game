using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canInteractWith = true;
    public virtual void Interact(Player character)
    {

    }
}
