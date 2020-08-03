using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TimelinePosition
{
    public Vector2 Position;
    public float Rotation;

    public void Apply(Transform transform)
    {
        transform.position = new Vector3(Position.x, 0f, Position.y);
        transform.rotation = Quaternion.Euler(0f, Rotation, 0f);
    }
}
