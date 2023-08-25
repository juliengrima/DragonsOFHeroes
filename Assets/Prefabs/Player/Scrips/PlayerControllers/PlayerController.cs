using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [Header("Actions_Components")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _fight;
    [Header("Audio_Components")]
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _AudioFight;
    [SerializeField] AudioClip _AudioJump;
    [Header("Animations_Components")]
    [SerializeField] Animator _animator;
    [SerializeField] GameObject graphics;
    [Header("Actions_Informations")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    bool _isButtonPressed;
    #endregion
    #region Instances
    public static PlayerController Instance 
    { 
        get; private set; 
    }
    private void Reset()
    {
        _speed = 5f;
        _jumpForce = 10f;
    }
    #endregion
    #region LifeCycle
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("OMG");
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = _move.action.ReadValue<Vector2>().x * _speed;
        Mouvements(xAxis);
        Animators(xAxis);
        UpdateRotation(xAxis);
        Jump();
        Fight();
    }
    #endregion
    #region Methods
    void Mouvements(float xAxis)
    {
        Vector2 direction = _move.action.ReadValue<Vector2>();
        _rb.velocity = direction * _speed;
        _animator.SetFloat("Speed", Mathf.Abs(xAxis));
        //Debug.Log($"Definition de l'axe de déplacement : {xAxis}");

    }

    void Jump()
    {
        _isButtonPressed = _jump.action.WasPressedThisFrame();
        //_isButtonPressed = _jump.action.IsPressed();
        //bool isGrounded = GroundChecker.IsGrounded;
        bool isGrounded = gameObject.GetComponentInChildren<GroundChecker>().IsGrounded;
        if (isGrounded)
        {

            //Debug.Log("IS PRESSED");
            if (_isButtonPressed)
            {
                _rb.AddForce(Vector2.up * _jumpForce);
                _source.PlayOneShot(_AudioJump);
                _animator.SetBool("IsJumping", true);
            }
        }
    }


    void Fight()
    {
        _isButtonPressed = _fight.action.WasPressedThisFrame();
        //Debug.Log("IS PRESSED");
        if (_isButtonPressed)
        {
            _source.PlayOneShot(_AudioFight);
            _animator.SetTrigger("IsShooting");
        }

    }

    private void Animators(float xAxis)
    {
        if (Mathf.Abs(xAxis) > 0.1f)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    private void UpdateRotation(float xAxis)
    {
        if (xAxis > 0)
        {
            graphics.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (xAxis < 0)
        {
            graphics.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    #endregion
    #region Coroutines
    #endregion
    //void GetNextWeaponByKey(InputAction.CallbackContext obj)
    //{
    //    throw new NotImplementedException();
    //}
}
