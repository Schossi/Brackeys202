using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedArgs : EventArgs
{
    public AttackType Type { get; private set; }
    public AttackArgs Args { get; private set; }

    public AttackedArgs(AttackType type, AttackArgs args)
    {
        Type = type;
        Args = args;
    }
}
