using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _spawnRate = 1f;
    [SerializeField] GameObject _enemy;
    [SerializeField] Transform _enemyRoot;
    [SerializeField] int enemyCount = 1;

    [SerializeField] List<GameObject> _spawnedEnemies;
    [SerializeField] UnityEvent _onSpawnCompleted;

    float _lastSpawnDate;       // 20
    float _randomDelay;

    private void Update()
    {
        if (Time.time > _lastSpawnDate + _spawnRate + _randomDelay && enemyCount > 0)  // LSD = 25     Rate = 5    Time.time => 30
        {
            _lastSpawnDate = Time.time;

            var go = Instantiate(_enemy, _enemyRoot);
            _spawnedEnemies.Add(go);

            _randomDelay = Random.value * 5;
            enemyCount--;
        }

        bool isFiniShed = true;

        foreach (var el in _spawnedEnemies)
        {
            if (el != null)
            {
                isFiniShed = false;
            }
        }
        if (isFiniShed && enemyCount <= 0)
        {
            _onSpawnCompleted.Invoke();
        }


    }






}