using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    Player player;
    Rigidbody2D rigidbody2d;
    [SerializeField]
    float offsetDistance = 1f;
    [SerializeField]
    float sizeOfInteractableArea = 1.2f;
    [SerializeReference]
    HighlightController highlightController;
    private void Awake()
    {
        player = GetComponent<Player>();
        rigidbody2d = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        CheckHightlightable();
        if (Input.GetMouseButtonDown(1))
        {
            Interact();
        }
    }

    private void CheckHightlightable()
    {
        Vector2 position = rigidbody2d.position + player.lastFacingDirection * offsetDistance;

        Collider2D[] collidersInArea = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D collider in collidersInArea)
        {
            LootContainerInteract lootContainerInteractable = collider.GetComponent<LootContainerInteract>();
            if (lootContainerInteractable != null && lootContainerInteractable.interactable.canInteractWith)
            {
                highlightController.Highlight(lootContainerInteractable.gameObject);
                return;
            }
            SignInteractable signInteractable = collider.GetComponent<SignInteractable>();
            if (signInteractable != null && signInteractable.interactable.canInteractWith)
            {
                highlightController.Highlight(signInteractable.gameObject);
                return;
            }
            ShopInteractable shopInteractable = collider.GetComponent<ShopInteractable>();
            if (shopInteractable != null && shopInteractable.interactable.canInteractWith)
            {
                highlightController.Highlight(shopInteractable.gameObject);
                return;
            }
        }
        highlightController.Hide();
    }

    private void Interact()
    {
        Vector2 position = rigidbody2d.position + player.lastFacingDirection * offsetDistance;

        Collider2D[] collidersInArea = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D collider in collidersInArea)
        {
            LootContainerInteract lootContainerInteractable = collider.GetComponent<LootContainerInteract>();
            if (lootContainerInteractable != null)
            {
                lootContainerInteractable.Interact();
                break;
            }
            SignInteractable signInteractable = collider.GetComponent<SignInteractable>();
            if (signInteractable != null)
            {
                signInteractable.Interact();
                break;
            }
            ShopInteractable shopInteractable = collider.GetComponent<ShopInteractable>();
            if (shopInteractable != null)
            {
                shopInteractable.Interact();
                break;
            }
        }
    }
}
