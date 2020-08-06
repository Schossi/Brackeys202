using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ExplodingProjectile : Projectile
{
    public float Radius;
    public Transform ExplosionVisualPrefab;

    protected override void hurt(IGetHurt hurter)
    {
        var hits = Physics.OverlapSphere(transform.position, Radius);

        foreach (var hit in hits)
        {
            hit.attachedRigidbody?.GetComponent<IGetHurt>()?.Hurt(Damage);
        }

        var visual = Instantiate(ExplosionVisualPrefab, transform.position, transform.rotation);
        visual.localScale = new Vector3(Radius, Radius, Radius);

        die();
    }
}
