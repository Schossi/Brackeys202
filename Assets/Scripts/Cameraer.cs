using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Cameraer : MonoBehaviour
{
    public static Cameraer Instance { get; private set; }

    public Camera Main;

    private Plane xzPlane = new Plane(Vector3.up, Vector3.zero);

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetMousePosition()
    {
        Ray mouseray = Main.ScreenPointToRay(Input.mousePosition);        
        if (xzPlane.Raycast(mouseray, out float hitdist))
            return mouseray.GetPoint(hitdist);
        if (hitdist < -1.0f)
            return mouseray.GetPoint(-hitdist);
        Debug.Log("ExtensionMethods_Camera.MouseOnPlane: plane is behind camera or ray is parallel to plane! " + hitdist);       // both are parallel or plane is behind camera so write a log and return zero vector
        return Vector3.zero;
    }

    public Vector3 GetScreenPosition(Vector3 worldPosition)
    {
       return Main.WorldToScreenPoint(worldPosition);
    }
}
