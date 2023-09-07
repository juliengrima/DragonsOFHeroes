using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorPosition : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] InputActionReference _cursorPos;

    private void Update()
    {
        var c = _cursorPos.action.ReadValue<Vector2>();
        Vector2 newPos = _camera.ScreenToWorldPoint(c);
        transform.position = newPos;
    }

}