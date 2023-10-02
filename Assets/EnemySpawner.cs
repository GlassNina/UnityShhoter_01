using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    public Transform[] _spawnPlace;                                                         //1

    private GameObject _enemy;
    private int _spawnRandomPlace;
    private float _angleRandom;

    void Start()
    {if (_enemyPrefab != null)
    {
        Debug.Log("Enemy Prefab is assigned.");
    }
    else
    {
        Debug.LogError("Enemy Prefab is not assigned!");
    }

        _spawnPlace = GetComponentsInChildren<Transform>();                                 //2
    }
    void Update()
    {
        EnemySpawn();
    }
    private void EnemySpawn()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(_enemyPrefab);
            _spawnRandomPlace = Random.Range(1, _spawnPlace.Length - 1);                    //3
            _enemy.transform.position = _spawnPlace[_spawnRandomPlace].transform.position;
            _angleRandom = Random.Range(0, 360);
            _enemy.transform.Rotate(0, _angleRandom, 0);
        }
    }
}