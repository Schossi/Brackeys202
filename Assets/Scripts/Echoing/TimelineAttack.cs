using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TimelineAttack
{
    public static TimelineAttack None => new TimelineAttack();

    public float Time;
    public AttackType Type;
    public AttackArgs Args;

    public bool Execute()
    {
        return Attacks.Execute(Type, Args);
    }
}
