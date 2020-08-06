using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{
    public static Vector3 MoverPosition;

    public Animator Animator;
    public Rigidbody Rigidbody;
    public float Speed;
    public bool IsSlowed;
    public bool IsStopped;
    public Transform Model;

    public bool IsMoving => GameManager.Instance == null || GameManager.Instance.State == GameState.Play;

    public float ModifiedSpeed
    {
        get
        {
            if (IsStopped)
                return 0f;
            else if (IsSlowed)
                return Speed / 2;
            else
                return Speed;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        MoverPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!IsMoving)
        {
            Rigidbody.velocity = Vector3.zero;
            Animator.SetFloat("speed", 0f);
            return;
        }

        float horizontal = Input.GetAxis(InputAxis.HORIZONTAL);
        float vertical = Input.GetAxis(InputAxis.VERTICAL);

        Vector2 movement = new Vector2(horizontal, vertical);

        if (movement.magnitude > 1.0f)
            movement.Normalize();

        Animator.SetFloat("speed", movement.magnitude * ModifiedSpeed / Speed);

        movement *= ModifiedSpeed;
        //movement *= Time.deltaTime;

        Rigidbody.velocity = new Vector3(movement.x, 0f, movement.y);

        Vector3 target;
        if (IsStopped || movement.magnitude < 0.2f)
            target = Cameraer.Instance.GetTargetPosition();
        else
            target = transform.position + movement.GetOutaXZ();
        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
    }
}
