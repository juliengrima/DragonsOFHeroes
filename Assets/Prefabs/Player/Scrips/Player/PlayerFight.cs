using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    #region Champs
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;

        if (collision.attachedRigidbody.gameObject.CompareTag("Enemy") || collision.attachedRigidbody.gameObject.CompareTag("Boss"))
        {
            collision.attachedRigidbody.GetComponent<Health>().IsDammageable = true;
        }    
    }
    public void OnTriggerExit2D(Collider2D collision)
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
