using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DrawAttacker : Attacker
{
    public float MinTime;
    public float PerfectTime;
    public float Tolerance;

    private float _downTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(InputAxis.ATTACK))
        {
            _downTime = Time.time;
        }

        if (Input.GetButtonUp(InputAxis.ATTACK))
        {
            var windupTime = Time.time - _downTime;

            if (windupTime >= MinTime)
            {
                float multiplier = Math.Min(windupTime / PerfectTime, 1.0f);
                bool isPerfect = Math.Abs(PerfectTime - windupTime) <= Tolerance;

                Attack(multiplier, isPerfect);
            }
        }

    }
}
