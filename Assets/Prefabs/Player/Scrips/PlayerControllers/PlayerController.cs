using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] Transform __playerScale;
    [SerializeField] Audios _audios;
    [Header("Actions_Components")]
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _run;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _fight;
    [SerializeField] Attack_1_ColDisabled _fightCollider2D;
    [Header("Animations_Components")]
    [SerializeField] Animator _animator;
    [SerializeField] GameObject PlayerGameObject;
    [Header("Actions_Informations")]
    [SerializeField] float _speed;
    [SerializeField] float _Running;

    Vector2 velocity;
    bool _isButtonPressed;
    int fightCounter = 0;
    int _jumpCounter = 3;
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
            Debug.LogError("Ganylene/Aïrynn/Wyllialys");
        }

        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        float xAxis = _move.action.ReadValue<Vector2>().x * _speed;     //action move dans axe X uniquement
        float yAxis = _move.action.ReadValue<Vector2>().y * _speed;     //action move dans axe y uniquement
        float XYaxis = xAxis + yAxis;                                   //addition des axes de move pour l'animation
        Mouvements(XYaxis);
        Jump();
        Fight();
        UpdateRotation(xAxis);
    }
    #endregion
    #region Methods
    void Mouvements(float XYaxis)
    {
        float scale = __playerScale.localScale.x;
        Debug.Log(scale);
        Vector2 direction = _move.action.ReadValue<Vector2>();
        _rb.velocity = direction * _speed;
        _animator.SetFloat("MoveSpeed", Mathf.Abs(XYaxis));

        if (direction.magnitude < 0)
        {
            _animator.SetFloat("MoveSpeed", Mathf.Abs(XYaxis));
        }
        else if (direction.magnitude > 0)
        {
            _animator.SetFloat("MoveSpeed", Mathf.Abs(XYaxis));
        }
        //RUNNING
        _isButtonPressed = _run.action.IsPressed();
        if (_isButtonPressed)
        {
            _rb.velocity = direction * _Running;
            _animator.SetBool("IsRunningBool", true);   
        }
        else
        {
            _animator.SetBool("IsRunningBool", false);
        }
    }
    void Jump()
    {
        _isButtonPressed = _jump.action.WasPressedThisFrame();
        if (_isButtonPressed)
        {
            _audios.Jump();
            _fightCollider2D.ColBodyDisabled();
            _animator.SetTrigger("IsJumping");
            for (int i = 0; i < _jumpCounter; i++)
            {
                _animator.SetInteger("JumpNumber", i);
            }
        }
        else
        {
            _fightCollider2D.ColBodyEnabled();
        }
    }
    void Fight()
    {
        _isButtonPressed = _fight.action.WasPressedThisFrame();
        if (_isButtonPressed)
        {
            _animator.SetTrigger("IsFighting");

            if (fightCounter == 3) fightCounter = 0;

            fightCounter++;
            StartCoroutine(ColEnableThenDisable());
            if (fightCounter == 1)
            {
                _audios.Attack(1);
                _animator.SetInteger("AttackNumber", 1);
            }
            else if (fightCounter == 2)
            {
                _audios.Attack(2);
                _animator.SetInteger("AttackNumber", 2);
                
            }
            else if (fightCounter == 3)
            {
                _audios.Attack(3);
                _animator.SetInteger("AttackNumber", 3);
                
            }
        }
    }
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
    IEnumerator ColEnableThenDisable()
    {
        yield return new WaitForFixedUpdate();
        _fightCollider2D.ColEnabled();

        yield return new WaitForFixedUpdate();
        _fightCollider2D.ColDisabled();
    }
    #endregion
}
