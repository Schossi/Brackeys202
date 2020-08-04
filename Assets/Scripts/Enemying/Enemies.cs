using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemies : MonoBehaviour
{
    public static Enemies Instance { get; private set; }

    public bool IsEmpty => _enemies.Count == 0;

    public event EventHandler Destroyed;

    private List<EnemyBase> _enemies = new List<EnemyBase>();

    private void Awake()
    {
        Instance = this;
    }

    public void DestroyEnemies()
    {
        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            Destroy(_enemies[i].gameObject);
        }
    }

    public void Register(EnemyBase enemy)
    {
        _enemies.Add(enemy);
    }

    public void Deregister(EnemyBase enemy)
    {
        _enemies.Remove(enemy);
        Destroyed?.Invoke(this, EventArgs.Empty);
    }
}
