using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "DrawConfig")]
public class DrawConfig : ScriptableObject
{
    public float MinTime;
    public float PerfectTime;
    public float Tolerance;
    public float Recovery;
    public bool IsCharger;
}