using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField]
    private float forceOfKnockback;
    [SerializeField]
    private float knockbackTime = 0.3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("PlayerTag"))
        {
            collision.gameObject.GetComponent<Pot>().SmashPot();
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("PlayerTag"))
        {
            Rigidbody2D otherRigidbody2D = collision.GetComponent<Rigidbody2D>();

            if (otherRigidbody2D != null)
            {
                Vector2 forceDirection = otherRigidbody2D.transform.position - transform.position;
                Vector2 force = forceDirection.normalized * forceOfKnockback;
                otherRigidbody2D.velocity = force;

                if (otherRigidbody2D.gameObject.CompareTag("Enemy"))
                {
                    otherRigidbody2D.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    otherRigidbody2D.GetComponent<Enemy>().Knockback(otherRigidbody2D, knockbackTime);
                }

                if (otherRigidbody2D.gameObject.CompareTag("PlayerTag"))
                {
                    otherRigidbody2D.GetComponent<Player>().state = PlayerState.stagger;
                    otherRigidbody2D.GetComponent<Player>().Knockback(knockbackTime);
                }
            }
        }
    }
}
