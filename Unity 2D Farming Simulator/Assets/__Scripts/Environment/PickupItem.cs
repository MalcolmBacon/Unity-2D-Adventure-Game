using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    public GameObject pickUpDrop;

    [SerializeField]
    public float spread = 0.7f;
    [SerializeField]
    public float minDropNumber = 2;
    [SerializeField]
    public float maxDropNumber = 5;
    public virtual void SpawnPickupItems()
    {
        float dropCount = Random.Range(minDropNumber, maxDropNumber);
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
