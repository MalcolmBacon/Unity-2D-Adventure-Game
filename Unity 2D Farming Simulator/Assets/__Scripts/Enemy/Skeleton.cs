using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    private Rigidbody2D skeletonRigidbody2D;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public float maxDistanceFromStartingPosition;
    private Animator animator;
    float distanceToTarget;
    private void Start()
    {
        currentState = EnemyState.idle;
        skeletonRigidbody2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("PlayerTag").transform;
        animator = GetComponent<Animator>();
        SetInitialAnimationStates();
    }
    void SetInitialAnimationStates()
    {
        //Set inital animation states
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }
    private void FixedUpdate()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
        && Vector3.Distance(target.position, transform.position) > attackRadius
         && currentState != EnemyState.stagger && currentState != EnemyState.attack) //Move towards player
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            ChangeAnimation(temp - transform.position);
            skeletonRigidbody2D.MovePosition(temp);
            ChangeState(EnemyState.walk);
            animator.SetBool("moving", true);
        }
        else if (currentState != EnemyState.stagger && currentState != EnemyState.attack
        && transform.position.x != startingPosition.x && transform.position.y != startingPosition.y) //Move towards starting position
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, startingPosition, moveSpeed * Time.deltaTime);
            ChangeAnimation(temp - transform.position);
            skeletonRigidbody2D.MovePosition(temp);
            ChangeState(EnemyState.walk);
            animator.SetBool("moving", true);
        }
        else if (currentState != EnemyState.stagger && currentState != EnemyState.attack) //Idle
        {
            ChangeState(EnemyState.idle);
            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", -1);
            animator.SetBool("moving", false);
        }
    }
    private void ChangeAnimation(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", 0);
            }
            else if (direction.x < 0)
            {
                animator.SetFloat("moveX", -1);
                animator.SetFloat("moveY", 0);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 1);
            }
            else if (direction.y < 0)
            {
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", -1);
            }
        }
    }
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
