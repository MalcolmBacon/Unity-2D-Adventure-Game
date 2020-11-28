using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignInteractable : _Interactable
{
    public string dialog;
    private PopupSystem pop;
    private void Start()
    {
        pop = GetComponent<PopupSystem>();

    }
    private void Update()
    {
        if (playerInRange)
        {
            base.Highlight(this.gameObject);
            if (Input.GetMouseButtonDown(1))
            {
                base.Interact(pop, dialog);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerInteractable") && other.isTrigger)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerInteractable") && other.isTrigger)
        {
            playerInRange = false;
            base.Hide();
        }
    }
}
