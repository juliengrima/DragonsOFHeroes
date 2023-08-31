using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMove : MonoBehaviour
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
        // L'IA n'a pas de manette, il a pas de touche assigné à son comportement
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
            //_animator.SetBool("Idle", true);
        }
        
        else


        {
            //_animator.SetBool("Idle", false);
        }


        if (dir.magnitude > 0)    // Direction de la magnitude au carré triangle rectancle pythagore
        {
            //_animator.SetBool("Walk", true);
        }

        else


        {
            //_animator.SetBool("Walk", false);
        }



    }

}



