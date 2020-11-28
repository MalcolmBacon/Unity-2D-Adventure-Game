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
    public Vector2 startingPosition;
    private float health;
    public float moveSpeed;
    public EnemyState currentState;
    public HealthObject maxHealth;
    public GameObject deathEffect;
    private PickupItem objectDestroyedPickupItem;
    private void Awake()
    {
        health = maxHealth.maxHealth;
        objectDestroyedPickupItem = GetComponent<PickupItem>();
        transform.position = startingPosition;
    }
    private void OnEnable()
    {
        transform.position = startingPosition;
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
        Debug.Log("In take damage");
        health -= damage; // / 2);
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            DeathEffect();
            SpawnPickupItems();
            ResetEnemyState();
        }
    }
    private void ResetEnemyState()
    {
        health = maxHealth.maxHealth;
        currentState = EnemyState.idle;
    }
    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }
    private void SpawnPickupItems()
    {
        Debug.Log("In spawn pickup items");
        if (objectDestroyedPickupItem != null)
        {
            objectDestroyedPickupItem.SpawnPickupItems();
        }
    }
}
