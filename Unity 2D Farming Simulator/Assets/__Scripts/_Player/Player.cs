using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    stagger,
    idle
}
public class Player : MonoBehaviour
{
    public PlayerState state;
    public float speed;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private Vector3 change;
    public Vector2 lastFacingDirection;
    // Start is called before the first frame update
    void Start()
    {
        state = PlayerState.walk;
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetInitialAnimationStates();
    }
    void SetInitialAnimationStates()
    {
        //Set inital animation states
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
        if (Input.GetButtonDown("attack") && state != PlayerState.attack && state != PlayerState.stagger)
        {
            StartCoroutine(AttackCoroutine());
        }
        else if (state == PlayerState.walk || state == PlayerState.idle)
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
            lastFacingDirection.x = change.x;
            lastFacingDirection.y = change.y;
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
    public void Knockback(float knockbackTime)
    {
        StartCoroutine(KnockbackCoroutine(knockbackTime));
    }
    private IEnumerator KnockbackCoroutine(float knockbackTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        playerRigidbody.velocity = Vector2.zero;
        state = PlayerState.idle;
        playerRigidbody.velocity = Vector2.zero;
    }
}
