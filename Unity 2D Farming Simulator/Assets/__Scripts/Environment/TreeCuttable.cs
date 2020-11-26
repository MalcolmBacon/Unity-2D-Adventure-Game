using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ObjectDestroyed
{
    public void CutDownTree()
    {
        SpawnPickupItems();
    }
    public override void SpawnPickupItems()
    {
        float dropCount = Random.Range(3f, 8f);
        while (dropCount > 0)
        {
            dropCount--;

            Vector3 newPosition = transform.position;
            newPosition.x += spread * UnityEngine.Random.value - spread / 2;
            newPosition.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject branch = Instantiate(pickUpDrop);
            branch.transform.position = newPosition;
        }
        
        gameObject.SetActive(false);
    }
}
