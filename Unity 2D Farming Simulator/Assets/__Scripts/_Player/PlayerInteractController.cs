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
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null && interactable.canInteractWith)
            {
                highlightController.Highlight(interactable.gameObject);
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
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(player);
                break;
            }
        }
    }
}
