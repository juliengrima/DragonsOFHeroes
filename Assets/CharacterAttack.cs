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

    private void Update()
    {


        //On check le bouton d' atttack quivient d'�tre enfonc�

        if (_attackInput.action.WasPressedThisFrame())
        {

            // C'est le cas o� on parcours la liste des colliders d�tect�s
            //Et sur chaque collider on choppe le composant Health et on appelle
            //takeDamage dessus.


            foreach (Collider2D col in _hitZone.Colliders)
            {

                Debug.Log($"attack {col.attachedRigidbody.name}");

                //Le composant Health est au m�me endroit que le RB de notre enemi

                Health h = col.attachedRigidbody.GetComponent<Health>();
                h.TakeDamage(_damage);

                {

                }
            }

        }
    }
}
