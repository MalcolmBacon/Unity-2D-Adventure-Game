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
    [SerializeField]
    private float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public EnemyState currentState;
    public HealthObject maxHealth;
    private void Awake() {
        health = maxHealth.maxHealth;
    }
    public void Knockback(Rigidbody2D otherRigidbody2D, float knockbackTime, float damage)
    {
        StartCoroutine(KnockbackCoroutine(otherRigidbody2D, knockbackTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockbackCoroutine(Rigidbody2D otherRigidbody2D, float knockbackTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        otherRigidbody2D.velocity = Vector2.zero;
        currentState = EnemyState.idle;
        otherRigidbody2D.velocity = Vector2.zero;
    }
    private void TakeDamage(float damage)
    {
        health -= (damage / 2);
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
