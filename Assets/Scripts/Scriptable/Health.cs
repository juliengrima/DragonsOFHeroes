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
    [SerializeField] int _startHealth;
    [SerializeField] int _startHealthMax;
    [Header("Scores")]
    [SerializeField] int _scoreOnDeath;
    [SerializeField] int _scoreOnLife;
    [SerializeField] bool _isPlayer = false;
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
        _effect.Invoke();
        _healthBar.SetMaxHealth(_startHealthMax);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }
    }
    #endregion
    #region Methods
    public void TakeDamage(int amount)
    {
        if (IsDammageable == false) return;

        _startHealth -= amount;
        _animator.SetBool("HasHurted", true);
        _healthBar.SetHealth(_startHealth);
        if (_startHealth <= 0)
        {
            if (_isPlayer == true)
            {
                StartCoroutine(loadingScene());    
            }
            else
            {
                ScoreManager.Instance.AddScore(_scoreOnDeath);
                StartCoroutine(EnableDestroyAfterDelay());
            }
            _effect.Invoke();
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
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
        yield return new WaitForSeconds(disableDuration);
        Destroy(gameObject);
    }
    public IEnumerator loadingScene()
    {
        _animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(disableDuration);
        SceneManager.GetActiveScene();
    }
    #endregion
}