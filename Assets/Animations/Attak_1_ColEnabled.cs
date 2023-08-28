using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attak_1_script : MonoBehaviour
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
    #endregion
    #region Coroutines
    #endregion
}
