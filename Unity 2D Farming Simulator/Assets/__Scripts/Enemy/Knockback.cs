using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public DamageDealtObject damageDealtObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("PlayerTag"))
        {
            collision.gameObject.GetComponent<Pot>().SmashPot();
        }
        if (collision.gameObject.CompareTag("Enemy") && collision.isTrigger || collision.gameObject.CompareTag("PlayerTag"))
        {
            Rigidbody2D otherRigidbody2D;

            if (collision.gameObject.CompareTag("Enemy"))
            {
                otherRigidbody2D = collision.GetComponentInParent<Rigidbody2D>();
            }
            else
            {
                otherRigidbody2D = collision.GetComponent<Rigidbody2D>();
            }

            if (otherRigidbody2D != null)
            {
                Vector2 forceDirection = otherRigidbody2D.transform.position - transform.position;
                Vector2 force = forceDirection.normalized * damageDealtObject.forceOfKnockback;
                otherRigidbody2D.velocity = force;

                if (otherRigidbody2D.gameObject.CompareTag("PlayerTag"))
                {
                    Player player = otherRigidbody2D.GetComponent<Player>();
                    if (player.state != PlayerState.stagger)
                    {
                        player.state = PlayerState.stagger;
                        player.Knockback(damageDealtObject.knockbackTime, damageDealtObject.damage);
                    }
                }
                else //Enemy
                {
                    Enemy enemy = otherRigidbody2D.GetComponent<Enemy>();

                    enemy.currentState = EnemyState.stagger;
                    enemy.Knockback(otherRigidbody2D, damageDealtObject.knockbackTime, damageDealtObject.damage);
                }
            }
        }
    }
}
