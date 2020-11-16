using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Reset change to 0
        change = Vector3.zero;
        //See if player if pressing down movement buttons
        change.x = Input.GetAxisRaw("Horizontal"); //using raw so that movement has no acceleration
        change.y = Input.GetAxisRaw("Vertical");
        MoveAndUpdateAnimation();
    }

    void MoveAndUpdateAnimation()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        //Call player rigidbody and move where we are plus the change
        playerRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
