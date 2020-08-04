using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawners : MonoBehaviour
{
    public static Spawners Instance { get; private set; }

    public bool IsFinished => _spawners.All(s => s.IsFinished);

    private List<Spawner> _spawners = new List<Spawner>();

    private void Awake()
    {
        Instance = this;
    }

    public void Register(Spawner spawner)
    {
        _spawners.Add(spawner);
    }

    public void Deregister(Spawner spawner)
    {
        _spawners.Remove(spawner);
    }
}
