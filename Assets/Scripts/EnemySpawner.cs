using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Используется паттерн - Пулинг объектов (Object Pool)*/

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private int _obejctPoolEnemy;
    [SerializeField] private bool _canSpawn = true;
    [SerializeField] private float _enemyCooldown = 1f;
    [SerializeField] private float _maxXDistance = 1f;

    private List<GameObject> _enemies = new List<GameObject>();

    public void Init()
    {
        InitEnemyObjectPool();
    }

    public void Begin()
    {
        StartCoroutine(SpawnTimer());
    }

    private void InitEnemyObjectPool()
    {
        for(int i = 0; i < _obejctPoolEnemy; i++)
        {
            var enemy = Instantiate(_prefabEnemy);
            _enemies.Add(enemy);
            enemy.SetActive(false);
        }
    }

    private IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(_enemyCooldown);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float randomX = Random.Range(-_maxXDistance, _maxXDistance);

        for(int i = 0; i < _enemies.Count; i++)
        {
            if (!_enemies[i].activeSelf)
            {
                _enemies[i].SetActive(true);
                _enemies[i].transform.position = new Vector3(randomX, _spawnPoint.position.y, 0);
                break;
            }
        }
    }
}
