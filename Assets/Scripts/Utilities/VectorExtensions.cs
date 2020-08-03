using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 GetIntoXZ(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.z);
    }
    public static Vector3 GetOutaXZ(this Vector2 vector, float y = 0f)
    {
        return new Vector3(vector.x, y, vector.y);
    }
    public static Vector3 GetOutaXZ(this Vector3 vector, float y = 0f)
    {
        return new Vector3(vector.x, y, vector.z);
    }
}
