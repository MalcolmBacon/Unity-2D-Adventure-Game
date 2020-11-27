using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopupSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        TMP_Text popUpText = popUpBox.GetComponentInChildren<TMP_Text>();
        popUpText.text = text;
        animator.SetTrigger("pop");
    }
}
