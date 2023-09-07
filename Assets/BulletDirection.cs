using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletDirection : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] int _damage;
    Vector2 _direction;

    internal void SetDirection(CursorPosition aimCursor)
    {
        _direction = (aimCursor.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        transform.Translate(_direction * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region 
        //// Methode tag
        //if(collision.gameObject.CompareTag("Boss"))
        //{
        //}

        // Component
        //EnemyTag tag = collision.gameObject.GetComponent<EnemyTag>();
        //if(tag != null)
        //{
        //    ScoreManager.Instance.AddScore(1);

        //    Destroy(tag.gameObject);
        //    Destroy(gameObject);
        //}
        #endregion

        if (collision.TryGetComponent(out Health enemy) && enemy.IsPlayer == false)
        {
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }

}