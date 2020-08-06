using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputAxis
{
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    public const string RHORIZONTAL = "RHorizontal";
    public const string RVERTICAL = "RVertical";
    public const string ATTACK = "Attack";

    public static Vector2 GetLeftStick()
    {
        float horizontal = Input.GetAxis(InputAxis.HORIZONTAL);
        float vertical = Input.GetAxis(InputAxis.VERTICAL);

        return new Vector2(horizontal, vertical);
    }
    public static Vector2 GetRightStick()
    {
        float horizontal = Input.GetAxis(InputAxis.RHORIZONTAL);
        float vertical = Input.GetAxis(InputAxis.RVERTICAL);

        return new Vector2(horizontal, vertical);
    }
}
