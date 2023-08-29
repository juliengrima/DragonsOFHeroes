using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    #region Champs
    [SerializeField] int _damage;
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
            Destroy(gameObject);
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
