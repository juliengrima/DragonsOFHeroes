using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    #region Champs
    [Header("Components")]
    [SerializeField] HealthBar _healthBar;
    [SerializeField] Animator _animator;
    [Header("Health")]
    [SerializeField] int _startHealth; //currentHealth
    [SerializeField] int _startHealthMax; //MaxHealth
    [Header("Scores")]
    [SerializeField] int _scoreOnDeath;
    [SerializeField] int _scoreOnLife;
    [SerializeField] bool _isPlayer = false; // Is true uniquely is player 
    [Header("Effects")]
    [SerializeField] float disableDuration = 1f;
    [SerializeField] UnityEvent _effect;

    public bool IsDammageable { get; set; }
    #endregion
    #region Unity LifeCycle
    private void Reset()
    {
        _startHealth = 100;
        _startHealthMax = 100;
        _scoreOnDeath = 200;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        _startHealth = _startHealthMax;
        if (_isPlayer) IsDammageable = true;
    }
    private void Start()
    {
        // Apparition effect
        _effect.Invoke();
        // Activation of HealthBar
        _healthBar.SetMaxHealth(_startHealthMax);
    }
    void Update()
    {
        // Enemy Simulation
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    TakeDamage(20);
        //}
    }
    #endregion
    #region Methods
    // Player or enemy can take damages
    public void TakeDamage(int amount)
    {
        // security condition
        if (IsDammageable == false) return;

        _startHealth -= amount;
        _animator.SetTrigger("HasHurted");
        _healthBar.SetHealth(_startHealth);
        // Death of player or Enemy
        if (_startHealth <= 0)
        {
            if (_isPlayer == true) // If is the payer
            {
                StartCoroutine(loadingScene());
            }
            else // Else is an Enemy
            {
                // Destroy enemy ... Instance Score => ScoreManager
                ScoreManager.Instance.AddScore(_scoreOnDeath);
                // Enemy is dead start event
                StartCoroutine(EnableDestroyAfterDelay());
            }
        }
    }
    public void GiveLife(int amount)
    {
        if (_startHealth > 0 && _startHealth < _startHealthMax)
        {
            _startHealth += amount;
            if (_startHealth > _startHealthMax)
            {
                _startHealth = _startHealthMax;
                ScoreManager.Instance.AddScore(_scoreOnLife);
                _effect.Invoke();
            }
        }  
    }
    #endregion
    #region Coroutines
    public IEnumerator EnableDestroyAfterDelay()
    {
        // Set collider at false before event
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
        //Event
        _effect.Invoke();
        yield return new WaitForSeconds(disableDuration);
        Destroy(gameObject);
    }
    public IEnumerator loadingScene()
    {
        _animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(disableDuration);
        var getScene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene();
    }
    #endregion
}