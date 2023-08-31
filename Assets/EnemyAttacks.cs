using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine;

using System.Collections;


public class EnemyAttack : MonoBehaviour
{
    #region Champs
    [Header("Components")]
    [SerializeField] Collider2D _attack;
    [SerializeField] Collider2D _body;
    [Header("Fields")]
    [SerializeField] int _damage;

    bool _collider2d;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
        }
    }
    #endregion
    #region Coroutines
    #endregion
}