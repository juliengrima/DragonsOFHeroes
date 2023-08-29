using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_1_ColDisabled : MonoBehaviour
{
    #region Champs
    bool _collider2d;
    [SerializeField] GameObject _body;
    [SerializeField] GameObject _attack;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    public void ColEnabled()
    {
        var collider = _attack.GetComponentInChildren<CircleCollider2D>();
        collider.enabled = true;
    }
    void ColDisabled()
    {
        var collider = _attack.GetComponentInChildren<CircleCollider2D>();
        collider.enabled = false;
    }
    void PlayerBodyColliderEnabled()
    {
        var collider = _body.GetComponent<CapsuleCollider2D>();
        collider.enabled = true;
    }
    void PlayerBodyColliderDisabled()
    {
        var collider = _body.GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
    }
    #endregion
    #region Coroutines
    #endregion
}
