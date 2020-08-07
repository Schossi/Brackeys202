using UnityEngine;

[CreateAssetMenu(menuName = "AttacksRepo")]
public class Attacks : ScriptableObject
{
    public Attack EarthAttack;
    public Attack WaterAttack;
    public Attack FireAttack;
    public Attack AirAttack;

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
            case AttackType.None:
                return null;
            case AttackType.Air:
                return Instance.AirAttack;
            case AttackType.Earth:
                return Instance.EarthAttack;
            case AttackType.Fire:
                return Instance.FireAttack;
            case AttackType.Water:
                return Instance.WaterAttack;
            default:
                return Instance.EarthAttack;
        }
    }

    public static bool Execute(AttackType type, AttackArgs args, bool isEcho)
    {
        var attack = GetAttack(type);

        if (attack == null)
            return false;

        attack.Execute(args, isEcho);
        return true;
    }
}
