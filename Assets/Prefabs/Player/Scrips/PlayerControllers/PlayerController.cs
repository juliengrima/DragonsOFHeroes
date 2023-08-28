using System;
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
    [SerializeField] InputActionReference _run;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _fight;
    [Header("Audio_Components")]
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _AudioFight;
    [SerializeField] AudioClip _AudioJump;
    [Header("Animations_Components")]
    [SerializeField] Animator _animator;
    [SerializeField] GameObject PlayerGameObject;
    [Header("Actions_Informations")]
    [SerializeField] float _speed;
    [SerializeField] float _Running;

    Vector2 velocity;
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
        _Running = 8f;
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
        float xAxis = _move.action.ReadValue<Vector2>().x * _speed;     //action move dans axe X uniquement 
        float yAxis = _move.action.ReadValue<Vector2>().y * _speed;     //action move dans axe y uniquement
        float XYaxis = xAxis + yAxis;                                   //addition des axes de move
        //Mouvements(XYaxis, xAxis, runXaxis);
        Mouvements(XYaxis);
        //Run();
        Jump();
        Fight();
        UpdateRotation(xAxis);
    }
    #endregion
    #region Methods
    void Mouvements(float XYaxis)
    { 
        Vector2 direction = _move.action.ReadValue<Vector2>();
        _rb.velocity = direction * _speed;
        _animator.SetFloat("IsWalking", Mathf.Abs(XYaxis));
        //RUNNING
        _isButtonPressed = _run.action.IsPressed();
        if (_isButtonPressed)
        {
            _rb.velocity = direction * _Running;
            _animator.SetBool("IsRunningBool", true);   
        }
    }
    //void Run()
    //{
        
    //}
    void Jump()
    {
        _isButtonPressed = _jump.action.WasPressedThisFrame();
        if (_isButtonPressed)
        {
            //_rb.AddForce(Vector2.up * _jumpForce);
            _source.PlayOneShot(_AudioJump);
            _animator.SetBool("IsJumping", true);
        }  
    }
    void Fight()
    {
        _isButtonPressed = _fight.action.WasPressedThisFrame();
        if (_isButtonPressed)
        {
            _source.PlayOneShot(_AudioFight);
            _animator.SetBool("IsFighting", true);
        }
    }
    //void Animators(float XYaxis, float _running)
    //{
    //    if (Mathf.Abs(XYaxis + _running) > 6f)
    //    {
    //        _animator.SetBool("IsRunningBool", true);
    //    }
    //    else
    //    {
    //        _animator.SetBool("IsRunningBool", false);
    //    }
    //}
    void UpdateRotation(float xAxis)
    {
        if (xAxis > 0)
        {
            PlayerGameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (xAxis < 0)
        {
            PlayerGameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
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
