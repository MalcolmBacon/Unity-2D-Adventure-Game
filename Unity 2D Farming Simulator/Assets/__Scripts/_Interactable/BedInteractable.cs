using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractable : _Interactable
{
    public FloatObject currentPlayerHealth;
    public Observer playerHealthObserver;
    private void Update()
    {
        if (playerInRange)
        {
            base.Highlight(this.gameObject);
            // base.CheckHighlightable(this.gameObject);
            if (Input.GetMouseButtonDown(1))
            {
                base.Interact(currentPlayerHealth, playerHealthObserver);
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
