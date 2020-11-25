using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMovement : MonoBehaviour
{
    public Vector2 minCameraPositionChange;
    public Vector2 maxCameraPositionChange;
    public Vector3 playerChange;
    private CameraMovement cameraMovement;
    private void Start() {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlayerTag") && !other.isTrigger) //player has two colliders, make sure only activating once
        {
            //Access camera and change what its offset is
            cameraMovement.minPosition += minCameraPositionChange;
            cameraMovement.maxPosition += maxCameraPositionChange;
            other.transform.position += playerChange;
        }
    }
}
