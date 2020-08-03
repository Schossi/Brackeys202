using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Attacker : MonoBehaviour
{
    public AttackType AttackType;

    public event EventHandler<AttackedArgs> Attacked;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack(float multiplier, bool isPerfect)
    {
        var args = new AttackArgs()
        {
            Position = transform.position,
            Rotation = transform.rotation,
            Multiplier = multiplier,
            IsPerfect = isPerfect
        };

        Attacks.Execute(AttackType, args);
        Attacked?.Invoke(this, new AttackedArgs(AttackType, args));
    }
}
