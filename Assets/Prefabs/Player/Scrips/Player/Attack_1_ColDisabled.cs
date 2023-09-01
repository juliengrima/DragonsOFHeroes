using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_1_ColDisabled : MonoBehaviour
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
    // Enable or Disable collider for Fight action
    //Attack Collider
    public void ColEnabled()
    {
        var collider = _attack.GetComponentInChildren<CircleCollider2D>();
        collider.enabled = true; 
    }
    public void ColDisabled()
    {
        var collider = _attack.GetComponentInChildren<CircleCollider2D>();
        collider.enabled = false;
    }
    //Body Collider
    public void ColBodyEnabled()
    {
        var collider = _body.GetComponentInChildren<CapsuleCollider2D>();
        collider.enabled = true;
    }
    public void ColBodyDisabled()
    {
        var collider = _body.GetComponentInChildren<CapsuleCollider2D>();
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) //Get Health script to give damage
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
