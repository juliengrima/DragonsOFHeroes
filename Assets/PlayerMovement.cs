using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] InputActionReference _moveInput;       // Vector2
    [SerializeField] InputActionReference _jumpInput;       // button / bool
    [SerializeField] GroundChecker _groundChecker;

    [Header("Animator")]
    [SerializeField] Animator _animator;

    [Header("Configuration")]
    [SerializeField] float _movementSpeed;
    [SerializeField] float _jumpPower;

    private void Update()
    {
        TryJump();

        // On récupère la direction droite/gauche du joystick que l'on augmente par la vitesse
        float xAxis = _moveInput.action.ReadValue<Vector2>().x * _movementSpeed;

        UpdateAnimator(xAxis);

        UpdateRotation(xAxis);
        AddMovement(xAxis);
    }

    private void AddMovement(float xAxis)
    {
        // On fourni une nouvelle velocité avec notre direction à nous MAIS 
        // en conservant la vitesse de chute de l'objet pour que la gravité s'accumule progressivement.
        _rb.velocity = new Vector2(xAxis, _rb.velocity.y);
    }

    private void TryJump()
    {
        // Si le joueur vient d'appuyer sur la touche de saut => on donne une impulsion vers le haut au rigidbody
        // On s'adresse également au GroundChecker pour savoir si on touche le sol ou pas.
        // Si on ne touche pas le sol => on n'autorise pas le saut.
        if (_jumpInput.action.WasPressedThisFrame() && _groundChecker.IsGrounded == true)
        {
            _rb.AddForce(new Vector2(0, _jumpPower));
        }
    }

    private void UpdateAnimator(float xAxis)
    {
        // Une fois que l'on sait que l'on veut se déplacer ou pas, on peut informer l'animator pour qu'il présente la bonne animation
        // Les deux lignes sont strictement equivalente, si le joueur a enclenché une direction (droite ou gauche) : On indique à l'animator que l'on marche.
        //if(xAxis > 0.1f || xAxis < -0.1f)
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Idle", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Idel", false);
        }

        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Walk", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Walk", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("IsRunning", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("IsRunning", false);
            _animator.SetFloat("Speed", Mathf.Abs(xAxis));
        }

        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Figth", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Figth", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Jump", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Jump", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("JumUp", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("JumpUp", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("JumpMax", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("JumpMax", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Smoove", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Smoove", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Smurf", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Smurf", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Wonder", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Wonder", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Supepower", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Supepower", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Drop", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("Drop", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("DropJump", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("DropJump", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("DropJumpMax", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("DropJumpMax", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("JumpAttack", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("JumpAttack", false);
        }

        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("JumpForce", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("JumpForce", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("SuperPowerForce", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("SuperPowerForce", false);
        }
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("Provoking", true);
            //_animator.SetFloat("Speed", Mathf.Abs(xAxis));    // On peut fournir d'autres info à l'animator dans cette situation là, du genre la valeur d'enfoncement du joystick
        }
        else
        {
            _animator.SetBool("provoking", false);
        }
    }

    private void UpdateRotation(float xAxis)
    {
        // On met à jour la rotation du personnage pour qu'il regarde dans la direction du joystick
        if (xAxis > 0)
        {
            // Droite
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (xAxis < 0)
        {
            // Gauche
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}