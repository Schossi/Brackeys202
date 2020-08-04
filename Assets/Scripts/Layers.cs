using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layers
{
    public static int Enemy;
    public static int Unit;
    public static int Projectile;
    public static int Ground;

    static Layers()
    {
        Enemy = LayerMask.NameToLayer("Enemy");
        Unit = LayerMask.NameToLayer("Unit");
        Projectile = LayerMask.NameToLayer("Projectile");
        Ground = LayerMask.NameToLayer("Ground");
    }
}
