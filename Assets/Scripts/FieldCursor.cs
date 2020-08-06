using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCursor : MonoBehaviour
{
    public static FieldCursor Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var stick = InputAxis.GetRightStick();

        if (stick.magnitude > 0.1f)
        {
            transform.position = Mover.MoverPosition + stick.normalized.GetOutaXZ() * 5f;
        }
        else
        {
            transform.position = Cameraer.Instance.GetMousePosition();
        }
    }

    public void ActivateCursor()
    {
        Cursor.visible = false;
        gameObject.SetActive(true);
    }

    public void DeactivateCursor()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
}
