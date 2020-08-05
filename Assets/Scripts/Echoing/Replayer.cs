using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayer : MonoBehaviour
{
    public Transform Position;

    public Timeline Timeline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!RewindableTimer.IsPlaying)
            return;

        Timeline.GetAttack(RewindableTimer.PrevTime, RewindableTimer.CurrTime).Execute();
    }

    private void FixedUpdate()
    {
        Timeline.GetPosition(RewindableTimer.CurrStep).Apply(Position);
    }
}
