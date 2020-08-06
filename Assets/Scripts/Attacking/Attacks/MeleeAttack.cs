using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/Melee")]
public class MeleeAttack : Attack
{
    public Melee Regular;
    public Melee Perfect;

    public override void Execute(AttackArgs args)
    {
        base.Execute(args);

        var melee = Instantiate(args.IsPerfect ? Perfect : Regular, args.Position, args.Rotation);
    }
}
