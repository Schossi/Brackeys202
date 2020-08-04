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
        transform.position = Cameraer.Instance.GetMousePosition();
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
