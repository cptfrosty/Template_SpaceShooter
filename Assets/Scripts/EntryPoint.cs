using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private PlayerLogic _playerLogic;

    private void Awake()
    {
        _spawner.Init();
        _playerLogic.Init();
        GameData.Score = 0;
    }

    private void Start()
    {
        _spawner.Begin();
        _playerLogic.Begin();
    }
}
