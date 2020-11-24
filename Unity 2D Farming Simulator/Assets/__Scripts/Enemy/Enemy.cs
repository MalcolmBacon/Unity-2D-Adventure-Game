using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public EnemyState currentState;
    public void Knockback(Rigidbody2D otherRigidbody2D, float knockbackTime)
    {
        StartCoroutine(KnockbackCoroutine(otherRigidbody2D, knockbackTime));
    }
    private IEnumerator KnockbackCoroutine(Rigidbody2D otherRigidbody2D, float knockbackTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        otherRigidbody2D.velocity = Vector2.zero;
        currentState = EnemyState.idle;
        otherRigidbody2D.velocity = Vector2.zero;
    }
}
