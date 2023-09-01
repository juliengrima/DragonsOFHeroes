using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    #region Champs
    [SerializeField] List<Collider2D> _colliders;

    public List<Collider2D> Colliders { get => _colliders; }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision) // Give bool true to damageable item
    {
        if (collision.attachedRigidbody == null) return;

        if (collision.attachedRigidbody.gameObject.CompareTag("Enemy") || collision.attachedRigidbody.gameObject.CompareTag("Boss"))
        {
            collision.attachedRigidbody.GetComponent<Health>().IsDammageable = true;
        }    
    }
    public void OnTriggerExit2D(Collider2D collision) // Give bool false to damageable item
    {
        if (collision.attachedRigidbody == null) return;

        if (collision.attachedRigidbody.gameObject.CompareTag("Enemy") || collision.attachedRigidbody.gameObject.CompareTag("Boss"))
        {
            collision.attachedRigidbody.GetComponent<Health>().IsDammageable = false;
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
