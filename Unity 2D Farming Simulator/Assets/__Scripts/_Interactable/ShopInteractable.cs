using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractable : _Interactable
{
    [SerializeField]
    GameObject panel;
    private void Update()
    {
        if (playerInRange)
        {
            base.Highlight(this.gameObject);
            if (playerInRange && Input.GetMouseButtonDown(1))
            {
                base.Interact(panel);
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
