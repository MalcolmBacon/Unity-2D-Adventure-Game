using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SmashPot()
    {
        animator.SetBool("smash", true);
        StartCoroutine(BreakCoroutine());
    }

    IEnumerator BreakCoroutine()
    {
        yield return new WaitForSeconds(0.24f);
        this.gameObject.SetActive(false);
    }
}
