using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attacks/Melee")]
public class MeleeAttack : Attack
{
    public Melee Regular;
    public Melee Perfect;

    public override void Execute(AttackArgs args, bool isEcho)
    {
        base.Execute(args, isEcho);

        var melee = Instantiate(args.IsPerfect ? Perfect : Regular, args.Position, args.Rotation);

        if (isEcho)
            melee.GetComponent<AudioSource>().volume *= 0.25f;

        Basecamp.Hit();
    }
}
