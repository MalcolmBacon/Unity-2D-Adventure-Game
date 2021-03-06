﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkInteract : _Interactable
{
    private void Update()
    {
        if (playerInRange)
        {
            base.Highlight(this.gameObject);
            if (Input.GetMouseButtonDown(1))
            {
                base.Interact("dialogue");
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
