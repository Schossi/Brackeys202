using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetHurt
{
    int HealthMax { get; }
    int HealthCurrent { get; }

    void Hurt(int amount);
}
