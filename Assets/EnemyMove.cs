using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] InputActionReference _moveInput;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        var dir = _moveInput.action.ReadValue<Vector2>();
        _rb.velocity = dir.normalized;
    }


}
