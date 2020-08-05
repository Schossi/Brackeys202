using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform Pivot;
    public Path Path;
    public Vector2 Offset;
    public float Speed;

    public event EventHandler Finished;

    private int _targetIndex;

    private Vector3 _pathPosition;

    private void Awake()
    {
        Followers.Instance.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _targetIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        move(Math.Abs(RewindableTimer.Delta * Speed));
        Pivot.localPosition = transform.worldToLocalMatrix.MultiplyVector(Offset.GetOutaXZ());
    }

    private void OnDestroy()
    {
        Followers.Instance.Deregister(this);
    }

    private void move(float movement)
    {
        if (_targetIndex == 0)
        {
            transform.position = Path.Points[0].position;
            transform.LookAt(Path.Points[1]);
            return;//start
        }
        else if (_targetIndex >= Path.Points.Length)
        {
            if (RewindableTimer.IsRewinding)
            {
                _targetIndex--;
            }
            else
            {
                transform.position = Path.Points[_targetIndex - 1].position;
                transform.LookAway(Path.Points[_targetIndex - 2].position);
                return;//end
            }
        }

        var origin = Path.Points[_targetIndex - 1];
        var target = Path.Points[_targetIndex];

        transform.LookAt(target);

        if (RewindableTimer.IsRewinding)
        {
            var distance = Vector3.Distance(transform.position, origin.position);

            if (movement > distance)
            {
                transform.position = origin.position;

                _targetIndex--;
                move(movement - distance);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, origin.position, movement);
            }
        }
        else
        {
            var distance = Vector3.Distance(transform.position, target.position);

            if (movement > distance)
            {
                transform.position = target.position;

                _targetIndex++;

                if (_targetIndex >= Path.Points.Length)
                    Finished?.Invoke(this, EventArgs.Empty);

                move(movement - distance);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, movement);
            }
        }
    }
}
