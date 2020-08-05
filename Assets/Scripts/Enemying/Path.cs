using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] Points;

    public Transform StartPosition => Points[0];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Apply(Transform transform, float time, float speed)
    {

    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < Points.Length; i++)
        {
            var previous = Points[i - 1];
            var current = Points[i];

            Gizmos.color = Color.red;
            Gizmos.DrawLine(previous.position.GetOutaXZ(1f), current.position.GetOutaXZ(1f));
        }
    }
}
