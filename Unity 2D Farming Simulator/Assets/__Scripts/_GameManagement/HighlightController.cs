using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField]
    GameObject highlighter;
    GameObject currentTarget;
    private void Awake() {
        currentTarget = null;
    }
    public void Highlight(GameObject target)
    {
        if (currentTarget == target)
        {
            return;
        }
        Vector3 position = target.transform.position + Vector3.up * 0.5f;
        Highlight(position);
    }
    public void Highlight(Vector3 position)
    {
        highlighter.SetActive(true);
        highlighter.transform.position = position;
    }
    public void Hide()
    {
        currentTarget = null;
        highlighter.SetActive(false);
    }
}
