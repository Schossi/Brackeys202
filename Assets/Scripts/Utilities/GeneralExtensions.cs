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

    public static void SetLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(left, rt.offsetMin.y);
    }

    public static void SetRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    public static void SetTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, -top);
    }

    public static void SetBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottom);
    }
}
