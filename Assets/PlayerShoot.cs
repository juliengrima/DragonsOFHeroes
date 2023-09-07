using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] InputActionReference _shoot;
    [SerializeField] CursorPosition _aimCursor;
    [SerializeField] float _fireRate;
    [SerializeField] BulletDirection _bd;
    [SerializeField] Transform _spawnPoint;

    [SerializeField] UnityEvent _onShoot;

    Coroutine ShootRoutine { get; set; }

    private void Start()
    {
        _shoot.action.started += ShootStart;
        _shoot.action.canceled += ShootStop;
    }

    private void ShootStart(InputAction.CallbackContext obj)
    {
        if (ShootRoutine != null) return;
        ShootRoutine = StartCoroutine(Shoot());
        IEnumerator Shoot()
        {
            var waiter = new WaitForSeconds(_fireRate);
            while (true)
            {
                _onShoot?.Invoke();
                Instantiate(_bd, _spawnPoint.position, Quaternion.identity).SetDirection(_aimCursor);
                yield return waiter;
            }
        }
    }

    private void ShootStop(InputAction.CallbackContext obj)
    {
        if (ShootRoutine == null) return;
        StopCoroutine(ShootRoutine);
        ShootRoutine = null;
    }

}