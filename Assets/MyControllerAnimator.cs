using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyControllerAnimator : MonoBehaviour
{

    [SerializeField] Animator _animator;

    [SerializeField] string _HelloWorldParam; 

    // Start is called before the first frame update
    private void Update()
    {
       
        _animator.SetBool("24", true);
        _animator.SetBool("24", false);
       // _animator.SetFloat("24",12f);
       // _animator.SetTrigger("24");
        _animator.SetBool("Flyer", true);
        _animator.SetBool("Flyer", false);
    }

}
