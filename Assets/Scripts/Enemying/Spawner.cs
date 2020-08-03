using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Path Path;
    public SpawnItem[] Items;

    public bool IsFinished { get; private set; }

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
                Instantiate(item.Prefab, Path.StartPosition.position, Quaternion.identity).Path = Path;
            }
        }
    }
}
