using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolsController : MonoBehaviour
{
    Player player;
    Rigidbody2D rigidbody2d;
    [SerializeField] 
    float offsetDistance = 1f;
    [SerializeField]
    float sizeOfInteractableArea = 1.2f;


    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Player>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 position = rigidbody2d.position + player.lastFacingDirection * offsetDistance;

        Collider2D[] collidersInArea = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D collider in collidersInArea)
        {
            ObjectDestroyed hit = collider.GetComponent<ObjectDestroyed>();
            if (hit != null)
            {
                hit.SpawnPickupItems();
                break;
            }
        }
    }
}
