using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
    public AttackType Type;

    public virtual void Execute(AttackArgs args)
    {

    }
}
