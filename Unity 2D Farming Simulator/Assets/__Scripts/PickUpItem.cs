using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float pickUpDistance = 1.5f;
    [SerializeField]
    private float timeToLeave = 10f;
    [SerializeField]
    private float collisionDistance = 0.1f;
    private void Awake() {
        player = GameManager.instance.player.transform;
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
