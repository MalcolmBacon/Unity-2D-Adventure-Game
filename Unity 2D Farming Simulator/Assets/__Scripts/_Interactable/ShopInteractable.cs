using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractable : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    public Interactable interactable = new Interactable();
    public void Interact()
    {
        interactable.Interact(panel);
    }
}
