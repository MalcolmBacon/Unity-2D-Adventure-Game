using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteractable : _Interactable
{
    [SerializeField]
    GameObject closedChest;
    [SerializeField]
    GameObject openChest;
    [SerializeField]
    public bool chestIsOpened;
    private PickupItem pickupItem;
    private void Start()
    {
        chestIsOpened = false;
        pickupItem = GetComponent<PickupItem>();
    }
    private void Update()
    {
        if (playerInRange)
        {
            base.Highlight(this.gameObject);
            if (Input.GetMouseButtonDown(1) && !chestIsOpened)
            {
                chestIsOpened = true;
                base.Interact(closedChest, openChest);
                pickupItem.SpawnPickupItems();
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
