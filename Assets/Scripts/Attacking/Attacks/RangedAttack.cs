using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/Ranged")]
public class RangedAttack : Attack
{
    public Projectile Regular;
    public Projectile Perfect;

    public override void Execute(AttackArgs args, bool isEcho)
    {
        base.Execute(args, isEcho);

        var projectile = Instantiate(args.IsPerfect ? Perfect : Regular, args.Position, args.Rotation);

        if (isEcho)
            projectile.GetComponent<AudioSource>().volume *= 0.25f;

        projectile.Speed *= args.Multiplier;

        Basecamp.Shoot();
    }
}
