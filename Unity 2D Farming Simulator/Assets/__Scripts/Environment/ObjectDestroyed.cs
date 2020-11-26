using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyed : MonoBehaviour
{
    [SerializeField]
    public GameObject pickUpDrop;

    [SerializeField]
    public float spread = 0.7f;
    public virtual void SpawnPickupItems()
    {

    }
    public virtual void SpawnPickupItems(GameObject pickUpDrop, float spread)
    {
        float dropCount = Random.Range(1f, 8f);
        while (dropCount > 0)
        {
            dropCount--;

            Vector3 newPosition = transform.position;
            newPosition.x += spread * UnityEngine.Random.value - spread / 2;
            newPosition.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject branch = Instantiate(pickUpDrop);
            branch.transform.position = newPosition;
        }
    }
}
