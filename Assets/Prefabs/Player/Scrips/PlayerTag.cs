using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTag : MonoBehaviour
{
    #region Champs
    //RaycastHit2D hit;
    //Vector2 direction;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hit = Physics2D.Raycast(this.gameObject.transform.position, direction);
        //Debug.DrawRay(transform.position, transform.rotation, Color.red);

        ////If something was hit
        //if (hit.collider != null)
        //{
        //    //If the object hit is less than or equal to 6 units away from this object.
        //    if (hit.distance <= 6.0f)
        //    {
        //        Debug.Log("Enemy In Range!");
        //    }
        //}
    }
    #endregion
    #region Methods
    void FixedUpdate (){
    }
    void LateUpdate (){
        
    }
    #endregion
}
