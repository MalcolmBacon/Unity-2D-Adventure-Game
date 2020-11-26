using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float pickUpDistance = 1.5f;
    [SerializeField]
    private float timeToLeave = 10f;
    [SerializeField]
    private float collisionDistance = 0.1f;
    public int count = 1;
    private GroundItem item;

    private void Awake()
    {
        player = GameManager.instance.player.transform;
        item = gameObject.GetComponent<GroundItem>();
    }
    private void Update()
    {
        DecreaseTime();

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        if (distance < collisionDistance)
        {
            if (GameManager.instance.playerInventory != null)
            {
                GameManager.instance.playerInventory.AddItem(new Item(item.item), 1);
            }
            else
            {
                Debug.LogWarning("No player inventory has been created yet");
            }
            Destroy(gameObject);
        }
    }
    private void DecreaseTime()
    {
        timeToLeave -= Time.deltaTime;
        if (timeToLeave <= 0)
        {
            Destroy(gameObject);
        }
    }

}
