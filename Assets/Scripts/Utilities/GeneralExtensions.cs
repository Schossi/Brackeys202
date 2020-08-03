using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralExtensions
{
    public static bool IsBetween(this float num, float min, float max)
    {
        if (num < min)
            return false;
        if (num > max)
            return false;
        return true;
    }

    public static void LookAway(this Transform transform, Vector3 position)
    {
        transform.LookAt(transform.position + transform.position - position);
    }
}
