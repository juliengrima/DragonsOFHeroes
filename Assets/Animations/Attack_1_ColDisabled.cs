using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_1_ColDisabled : MonoBehaviour
{
    #region Champs
    bool _collider2d;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    public void ColEnabled()
    {
        var collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = true;
    }
    void ColDisabled()
    {
        var collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
    }
    #endregion
    #region Coroutines
    #endregion
}
