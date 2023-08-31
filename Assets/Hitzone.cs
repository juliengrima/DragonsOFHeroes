using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitZone : MonoBehaviour
{
    [SerializeField] List<Collider2D> _colliders;

    public List<Collider2D> Colliders { get => _colliders; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si l'objet detect� n'a pas de rigidbody => on ignore il nous int�resse pas
        if (collision.attachedRigidbody == null) return;
        // En revanche s'il a un rigidbody, donc le tag est "Enemy", l� on va l'ajouter � notre liste
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