using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    [SerializeField] int _damageAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health pc) && pc.IsPlayer)
        {

            pc.TakeDamage(_damageAmount);
            Destroy(gameObject);

        }


    }
}