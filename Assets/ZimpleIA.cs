using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cas typique d'un State Machine
/// </summary>
public class SimpleAI : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] HitZone _hitZone;


    [SerializeField] float _walkSpeed;

    [Header("IA Configuration")]
    [Header("Patrol")]
    [SerializeField] float _patrolToAggroDistance;
    [Header("Aggro")]
    [SerializeField] float _aggroToAttackDistance;
    [SerializeField] float _aggroToPatrolDistance;
    [Header("Attack")]
    [SerializeField] float _attackToAggroDistance;

    enum State { Patrol, Aggro, Attack }

    State _state;
    Coroutine _attackCoroutine;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Aggro:
                Aggro();
                break;
            case State.Attack:
                Attack();
                break;
            default:
                break;
        }
    }

    void Patrol()
    {
        // RIEN


        // Transitions
        if (Vector2.Distance(transform.position, _player.transform.position) < _patrolToAggroDistance)
        {
            _state = State.Aggro;
        }
    }

    void Aggro()
    {
        // On se rapproche vers le joueur
        Vector3 dir = _player.transform.position - transform.position;
        dir.Normalize();
        dir *= _walkSpeed;
        _rb.velocity = dir;

        // Update character's orientation
        if (dir.x > 0) // Right
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dir.x < 0)  // Left
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Transitions
        if (Vector2.Distance(transform.position, _player.transform.position) < _aggroToAttackDistance)
        {
            // Le joueur est très proche : on attack
            _state = State.Attack;
        }
        else if (Vector2.Distance(transform.position, _player.transform.position) > _aggroToPatrolDistance)
        {
            // Le joueur nous a distancé : on retourne à notre patrouille
            _state = State.Patrol;
        }
    }

    void Attack()
    {
        if (_attackCoroutine == null)
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }

        // Transitions
        if (Vector2.Distance(transform.position, _player.transform.position) > _attackToAggroDistance)
        {
            // Le joueur nous a distancé : on retourne à notre patrouille
            _state = State.Aggro;
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }

    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            Debug.Log("J'attaque");
            // On attack le joueur
            foreach (Collider2D col in _hitZone.Colliders)
            {
                Debug.Log($"attack {col.attachedRigidbody.name}");
                // Le composant Health est au même endroit que le RB de notre ennemi
                Health h = col.attachedRigidbody.GetComponent<Health>();
                // On peut appeller TakeDamage dessus
                h.TakeDamage();
            }

            yield return new WaitForSeconds(1f);
        }
    }



    private void OnDrawGizmos()
    {
        if (_state == State.Patrol)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, _patrolToAggroDistance);
        }

        if (_state == State.Aggro)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _aggroToAttackDistance);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _aggroToPatrolDistance);
        }

        if (_state == State.Attack)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, _attackToAggroDistance);
        }
    }

}