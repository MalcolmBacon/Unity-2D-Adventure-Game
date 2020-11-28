using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public Pot[] pots;
    public TreeCuttable[] trees;
    public virtual void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlayerInteractable") && other.isTrigger)
        {
            bool activation = true;
            //When entering a room, set all game objects in that room to active
            for (int i = 0; i < enemies.Length; i++)
            {
                Debug.Log("in enemie change activation");
                ChangeActivation(enemies[i], activation);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], activation);
            }
            for (int i = 0; i < trees.Length; i++)
            {
                ChangeActivation(trees[i], activation);
            }
        }
    }
    public virtual void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("PlayerInteractable") && other.isTrigger)
        {
            bool activation = false;
            //When you are leaving a room, set all game objects in that room to inactive
            for (int i = 0; i < enemies.Length; i++)
            {
                ChangeActivation(enemies[i], activation);
            }
            for (int i = 0; i < pots.Length; i++)
            {
                ChangeActivation(pots[i], activation);
            }
            for (int i = 0; i < trees.Length; i++)
            {
                ChangeActivation(trees[i], activation);
            }
        }
    }
    void ChangeActivation(Component component, bool activation)
    {
        component.gameObject.SetActive(activation);
    }
}
