using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAttack : MonoBehaviour
{

    [SerializeField] InputActionReference _attackInput;
    [SerializeField] HitZone _hitZone;

    [SerializeField] Animator _animator;
    [SerializeField] AudioSource _punchSound;

    [Header("Fields")]
    [SerializeField] int _damage;

    private void FixedUpdate()
    {
        // On verifie si le bouton d'attaque vient d'etre enfonce
        if (_attackInput.action.WasPressedThisFrame())
        {
            // C'est le cas, on parcourt la liste des colliders detectes
            // Et sur chaque collider on recupere le composant Health et on appelle
            // takeDamage dessus.
            foreach (Collider2D col in _hitZone.Colliders)
            {
                Debug.Log($"attack {col.attachedRigidbody.name}");

                // Le composant Health est au meme endroit que le RB de notre ennemi
                Health h = col.attachedRigidbody.GetComponent<Health>();
                h.TakeDamage(_damage);
            }
        }
    }

}