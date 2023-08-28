using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] int _damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Component
        //EnemyTag tag = collision.gameObject.GetComponent<EnemyTag>();
        if (collision.attachedRigidbody == null) return;
        //if (tag != null)
        if (collision.CompareTag("Player"))
        {
            // VERIFICATION DES COLLIDERS DU RIGIDBODY DE HUMAN
            if (collision.attachedRigidbody.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damageAmount);
                //Destroy(gameObject);
            }
        }
    }
}