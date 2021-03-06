﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Path Path;
    public SpawnItem[] Items;

    public bool IsFinished => RewindableTimer.CurrTime > Items.Last().Time;

    private void Awake()
    {
        Spawners.Instance.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RewindableTimer.IsRewinding || !RewindableTimer.IsPlaying)
            return;

        foreach (var item in Items)
        {
            if (item.Time.IsBetween(RewindableTimer.PrevTime, RewindableTimer.CurrTime))
            {
                spawn(item);
            }
        }
    }

    private void OnDestroy()
    {
        Spawners.Instance.Deregister(this);
    }

    private void spawn(SpawnItem item)
    {
        if (item.Formation == null)
        {
            spawn(item.Prefab, Vector2.zero);
        }
        else
        {
            foreach (var position in item.Formation.Positions)
            {
                spawn(item.Prefab, position);
            }
        }
    }

    private void spawn(Follower prefab, Vector2 position)
    {
        var follower = Instantiate(prefab, Path.StartPosition.position, Quaternion.identity);
        follower.Path = Path;
        follower.Offset = position;
    }
}
