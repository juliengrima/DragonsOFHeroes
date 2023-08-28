using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRush : MonoBehaviour
{

    #region Variables

    [SerializeField] string targetName;
    public float m_moveSpeed = 4f;

    private Rigidbody2D rb2d;
    private GameObject _target;
    private Animator _animator;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _target = GameObject.Find(targetName);
        rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void FixedUpdate()

    {

        Vector3 direction = _target.transform.position - transform.position; //position cible ---> objet lui même
        rb2d.velocity = direction.normalized * m_moveSpeed; //vecteur de déplacement de notre objet longeur v>0 

        //bool hearquake = rb2d.velocity.magnitude > 0f; //true false marche --> vréation de la bonne valeur animation
        //_animator.SetBool("hearquake", hearquake); // méthode appelé à chaque frame physique

    }



}