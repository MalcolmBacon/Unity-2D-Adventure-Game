using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerStartPosition;
    public Vector2Object playerStorage;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlayerTag") && !other.isTrigger)
        {
            playerStorage.initialValue = playerStartPosition;
            SceneManager.LoadScene(sceneToLoad);
        }  
    }
}
