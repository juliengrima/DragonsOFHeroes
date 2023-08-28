using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DoorW : MonoBehaviour
{
    [SerializeField] string _sceneNameToLoad;
    [SerializeField] UnityEvent _onFinish;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody != null)
        {
            _onFinish.Invoke();
            SceneManager.LoadScene(_sceneNameToLoad);

        }
    }
}