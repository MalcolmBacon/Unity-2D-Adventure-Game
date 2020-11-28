using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Interactable : MonoBehaviour
{
    public GameObject highlighter;
    public bool canInteractWith { get; set; }
    public bool playerInRange { get; set; }
    public _Interactable()
    {
        canInteractWith = true;
        playerInRange = false;
    }
    public void Highlight(GameObject objectToHighlight)
    {
        if (highlighter == null)
        {
            throw new System.Exception("Highlighter not assigned in inspector");
        }
        if (canInteractWith)
        {
            highlighter.SetActive(true);
            highlighter.transform.position = objectToHighlight.transform.position + Vector3.up * 0.8f;
        }
    }
    public void Hide()
    {
        if (highlighter == null)
        {
            throw new System.Exception("Highlighter not assigned in inspector");
        }
        highlighter.SetActive(false);
    }
    public virtual void Interact()
    {
    }
    public virtual void Interact(string dialogue)
    {
        Debug.Log(dialogue);
    }
    public virtual void Interact(PopupSystem pop, string dialog)
    {
        pop.PopUp(dialog);
    }
    public virtual void Interact(GameObject panel)
    {
        if (panel.activeInHierarchy)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
    public virtual void Interact(FloatObject currentPlayerHealth, Observer playerHealthObserver)
    {
        Debug.Log("Current run time value before: " + currentPlayerHealth.runTimeValue);
        currentPlayerHealth.runTimeValue = currentPlayerHealth.maxRunTimeValue;
        Debug.Log("Current run time value after resting: " + currentPlayerHealth.runTimeValue);
        playerHealthObserver.Raise();
    }
    public virtual void Interact(GameObject closedChest, GameObject openChest)
    {
        canInteractWith = false;
        closedChest.SetActive(false);
        openChest.SetActive(true);
    }
}
