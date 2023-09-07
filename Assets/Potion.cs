using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Potion : MonoBehaviour
{

    [SerializeField] int _regenAmount;
    [SerializeField] UnityEvent _onPicked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var health = collision.gameObject.GetComponent<Health>();

            health.GiveLife(_regenAmount);
            _onPicked.Invoke();

            //gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }



}