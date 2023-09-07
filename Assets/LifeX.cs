using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeX : MonoBehaviour
{
    [SerializeField] int _startHealth;
    [SerializeField] Animator _animator;
    [SerializeField] UnityEvent _onDamage;

    public void TakeDamage()
    {

        _startHealth -= 10;

        // Feedback
        _animator.SetTrigger("Hurt");
        _onDamage.Invoke();

        // Death 
        if (_startHealth <= 0)
        {
            Destroy(gameObject);


            //StartCoroutine(  DeathCoroutine()  );
        }

    }

    // Si on veut lancer une animation avant de faire le destroy
    IEnumerator DeathCoroutine()
    {
        // Animator


        // Wait
        yield return new WaitForSeconds(2);

        // Destroy
        Destroy(gameObject);
    }

}