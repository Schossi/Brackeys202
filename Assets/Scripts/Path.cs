using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] Points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < Points.Length; i++)
        {
            var previous = Points[i - 1];
            var current = Points[i];

            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(previous.position.x, 1f, previous.position.z), new Vector3(current.position.x, 1f, current.position.z));
        }
    }
}
