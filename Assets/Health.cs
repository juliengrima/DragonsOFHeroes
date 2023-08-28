using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] bool _isPlayer;
    [SerializeField] int _scoreOnDeath;

    [Header("Health")]
    [SerializeField] int _currentHealth;
    [SerializeField] int _maxHealth;

    [Header("Events")]
    [SerializeField] UnityEvent _onPlayerDamage;

    public bool IsPlayer { get => _isPlayer; set => _isPlayer = value; }

    private void Reset()
    {
        _currentHealth = 30;
        _scoreOnDeath = 10;
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        _onPlayerDamage?.Invoke();


        if (_currentHealth <= 0)
        {
            if (_isPlayer)
            {
                // Reload Menu
                SceneManager.LoadScene("Menu");
            }
            else
            {
                ScoreManager.Instance.AddScore(_scoreOnDeath);
            }

            Destroy(gameObject);
        }

    }

    public void Heal(int amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

    }


}