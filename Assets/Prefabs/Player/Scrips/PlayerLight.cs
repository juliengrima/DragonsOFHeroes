using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    //quand enemy rentre dans le collider 
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // Component
    //    if (collision.attachedRigidbody == null) return;

    //    if (collision.attachedRigidbody.gameObject.GetComponent<EnemyTag>())
    //    {
    //        collision.attachedRigidbody.GetComponent<Health>().IsDammageable = true;
    //    }
    //    if (collision.attachedRigidbody.CompareTag("Boss"))
    //    {
    //        EnemyController ghost = collision.GetComponent<EnemyController>();
    //        if (ghost != null)
    //        {
    //            // Le fantôme est touché par la lumière, appelez la méthode "HitByLight"
    //            //ghost.HitByLight();
    //        }
    //    }
    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.attachedRigidbody == null) return;

    //    EnemyTag tag = collision.attachedRigidbody.gameObject.GetComponent<EnemyTag>();
    //    if (tag != null)
    //    {

    //        collision.attachedRigidbody.GetComponent<Health>().IsDammageable = false;

    //    }
    //}
}