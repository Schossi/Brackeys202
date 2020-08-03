using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Timeline
{
    private List<TimelinePosition> _positions = new List<TimelinePosition>();
    private List<TimelineAttack> _attacks = new List<TimelineAttack>();

    public void AddPosition(Vector3 position, Quaternion rotation)
    {
        _positions.Add(new TimelinePosition()
        {
            Position = position.GetIntoXZ(),
            Rotation = rotation.eulerAngles.y
        });
    }
    public void AddAttack(float time, AttackType type, AttackArgs args)
    {
        _attacks.Add(new TimelineAttack()
        {
            Time = time,
            Type = type,
            Args = args
        });
    }

    public TimelinePosition GetPosition(int currentStep)
    {
        currentStep = Math.Min(currentStep, _positions.Count - 1);
        currentStep = Math.Max(currentStep, 0);

        return _positions[currentStep];
    }
    public TimelineAttack GetAttack(float previousTime, float currentTime)
    {
        foreach (var attack in _attacks)
        {
            if (attack.Time > currentTime)
                return TimelineAttack.None;
            if (attack.Time > previousTime)
                return attack;
        }

        return TimelineAttack.None;
    }
}
