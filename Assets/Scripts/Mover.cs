using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed;

    public bool IsMoving => GameManager.Instance == null || GameManager.Instance.State == GameState.Play;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMoving)
            return;

        transform.LookAt(Cameraer.Instance.GetMousePosition());
    }

    private void FixedUpdate()
    {
        if (!IsMoving)
        {
            Rigidbody.velocity = Vector3.zero;
            return;
        }

        float horizontal = Input.GetAxis(InputAxis.HORIZONTAL);
        float vertical = Input.GetAxis(InputAxis.VERTICAL);

        Vector2 movement = new Vector2(horizontal, vertical);

        if (movement.magnitude > 1.0f)
            movement.Normalize();

        movement *= Speed;
        //movement *= Time.deltaTime;

        Rigidbody.velocity = new Vector3(movement.x, 0f, movement.y);
    }
}
