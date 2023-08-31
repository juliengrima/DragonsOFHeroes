using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    [SerializeField] List<Collider2D> _colliders;

    public List<Collider2D> Colliders { get => _colliders; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si l'objet detecté n'a pas de rigidbody => on ignore il nous intéresse pas
        if (collision.attachedRigidbody == null) return;
        // En revanche s'il a un rigidbody, donc le tag est "Enemy", là on va l'ajouter à notre liste
        if (collision.attachedRigidbody.gameObject.CompareTag("Enemy"))
        {
            _colliders.Add(collision);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) return;
        if (collision.attachedRigidbody.gameObject.CompareTag("Enemy"))
        {
            _colliders.Remove(collision);
        }
    }

}