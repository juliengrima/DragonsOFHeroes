using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;

    private void Update()
    {
        if (PlayerController.Instance == null) return;

        var dir = (PlayerController.Instance.transform.position - transform.position).normalized;

        if (dir.magnitude < 2f)
        {
            _rb.velocity = Vector3.zero;
        }
        else
        {
            _rb.velocity = dir * _speed;
        }


    }


}