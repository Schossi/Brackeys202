using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buyable : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public string Group;

    public abstract bool CanBuy { get; }
    public abstract int Cost { get; }

    public abstract void Buy();
}
