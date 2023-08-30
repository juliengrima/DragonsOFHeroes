using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cas typique d'un State Machine
/// </summary>
public class ZimpleAI : MonoBehaviour //Passfinding
{
    [SerializeField] GameObject _player;

    enum State { Patrol, Aggro, Attack }

    State _state;

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
        if (Vector2.Distance(transform.position, _player.transform.position) < 5f)
        {
            _state = State.Aggro;
        }
    }

    void Aggro()
    {
        // On se rapproche vers le joueur


        // Transitions
        if (Vector2.Distance(transform.position, _player.transform.position) < 1f)
        {
            // Le joueur est très proche : on attack
            _state = State.Attack;
        }
        else if (Vector2.Distance(transform.position, _player.transform.position) > 8f)
        {
            // Le joueur nous a distancé : on retourne à notre patrouille
            _state = State.Patrol;
        }

    }

    void Attack()
    {
        // On attack le joueur


        // Transitions
        if (Vector2.Distance(transform.position, _player.transform.position) > 2f)
        {
            // Le joueur nous a distancé : on retourne à notre patrouille
            _state = State.Aggro;
        }

    }

}