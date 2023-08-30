using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemymoveVs2 : MonoBehaviour
{
    //call instance
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _distance;
    [SerializeField] Animator _animator; //+

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    void Update()
    {
        var dir = _moveInput.action.ReadValue<Vector2>();
        _rb.velocity = dir * _speed;

        //Update character's orientation

        if (dir.x > 0) // direction Droite Rigth

        {

            //######################################################
            //La rotation
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }

        else if (dir.x < 0) // direction Gauche left

        {

            //######################################################
            //La rotation
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        //+Animator+Update _animator paramètre set bool, set float, set Trigger, set Integer


        if (dir.magnitude > 0)    // Direction de la magnitude au carré triangle rectancle pythagore
        {
            _animator.SetFloat("Idle",0 );
        }

        else


        {
            _animator.SetFloat("Idle", 0);
        }


        if (dir.magnitude > 0)    // Direction de la magnitude au carré triangle rectancle pythagore
        {
            _animator.SetFloat("Walk", 5);
        }

        else


        {
            _animator.SetFloat("Walk", 10);
        }
        if (dir.magnitude > 0)    // Direction de la magnitude au carré triangle rectancle pythagore
        {
            _animator.SetFloat("Attack1", 10);
        }

        else


        {
            _animator.SetFloat("Attack1", 10);
        }

    }

}