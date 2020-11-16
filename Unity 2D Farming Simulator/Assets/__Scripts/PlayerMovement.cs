using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState state;
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private Vector3 change;
    // Start is called before the first frame update
    void Start()
    {
        state = PlayerState.walk;
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        //Reset change to 0
        change = Vector3.zero;
        //See if player if pressing down movement buttons
        change.x = Input.GetAxisRaw("Horizontal"); //using raw so that movement has no acceleration
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && state != PlayerState.attack)
        {
            Debug.Log("Pressed attack");
            StartCoroutine(AttackCoroutine());
        }
        else if (state == PlayerState.walk)
        {
            MoveAndUpdateAnimation();
        }
    }
    //Coroutine -> method that allows you to pass in values to wait, allows you to build in specific delays
    private IEnumerator AttackCoroutine()
    {
        animator.SetBool("attacking", true);
        state = PlayerState.attack;
        yield return null; // wait one frame 
        // don't automatically go back into attack animation
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.16f); 
        state = PlayerState.walk;
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
