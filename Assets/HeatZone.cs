using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatZone : MonoBehaviour
{
    [SerializeField] List<Collider2D> _colliders;


    private void OnTriggerEnter2D(Collider2D collision) // → ☺
    {
            //Si 'objet de collision a pas de RigidBody on l' ignore. //Xcollider
        if (collision.attachedRigidbody == null) return; 

           // Si on remonte jusqu' au Rigidbody as tu le Tag witness

        if (collision.attachedRigidbody.gameObject.CompareTag("Player"))

        _colliders.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision) // ← ☻
    {
        if (collision.attachedRigidbody == null) return;
        if (collision.attachedRigidbody.gameObject.CompareTag("Player"))
            _colliders.Remove(collision); 
    }


    public IEnumerable<Collider2D> Colliders { get; internal set; }

}
