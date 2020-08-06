using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TimelinePosition
{
    public Vector2 Position;
    public float Rotation;

    public Vector2 Apply(Transform transform)
    {
        var newPosition = new Vector3(Position.x, 0f, Position.y);
        var delta = newPosition - transform.position;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0f, Rotation, 0f);
        return delta;
    }
}
