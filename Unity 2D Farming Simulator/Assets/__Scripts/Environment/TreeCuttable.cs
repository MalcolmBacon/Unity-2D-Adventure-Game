using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField]
    GameObject pickUpDrop;
    
    [SerializeField] 
    private float spread = 0.7f;
    public override void Hit()
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

        Destroy(gameObject);
    }
}
