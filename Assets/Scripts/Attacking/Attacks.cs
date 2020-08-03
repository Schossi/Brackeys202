using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AttacksRepo")]
public class Attacks : ScriptableObject
{
    public Attack ArrowAttack;

    private static Attacks _instance;
    private static Attacks Instance
    {
        get
        {
            if (_instance == null)
                _instance = (Attacks)Resources.Load("Attacks");
            return _instance;
        }
    }

    public static Attack GetAttack(AttackType type)
    {
        switch (type)
        {
            case AttackType.Arrow:
                return Instance.ArrowAttack;
            default:
                return null;
        }
    }

    public static void Execute(AttackType type, AttackArgs args)
    {
        var attack = GetAttack(type);

        if (attack == null)
            return;

        attack.Execute(args);
    }
}
