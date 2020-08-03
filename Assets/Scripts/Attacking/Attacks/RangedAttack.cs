using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/Ranged")]
public class RangedAttack : Attack
{
    public Projectile Regular;
    public Projectile Perfect;

    public override void Execute(AttackArgs args)
    {
        base.Execute(args);

        var projectile = Instantiate(args.IsPerfect ? Perfect : Regular, args.Position, args.Rotation);

        projectile.Speed *= args.Multiplier;
    }
}
