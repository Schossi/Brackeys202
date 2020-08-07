using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public const float OffsetFactor = 1.8f;
    public const float SpeedFactor = 0.65f;

    public Animator Animator;
    public Transform Pivot;
    public Path Path;
    public Vector2 Offset;
    public float Speed;

    public event EventHandler Finished;

    private int _targetIndex;
    private float _stunDuration;
    private float _slowDuration;

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
        float speed = 1f;

        if (!RewindableTimer.IsPlaying)
            speed = 0f;
        else if (_stunDuration > 0f)
            speed = 0f;
        else if (_slowDuration > 0f)
            speed = 0.5f;

        Animator.SetFloat("speed", speed);

        if (_stunDuration > 0f)
        {
            _stunDuration -= Time.deltaTime;
        }
        else
        {
            if (_slowDuration > 0f)
            {
                _slowDuration -= Time.deltaTime;
                move(Math.Abs(RewindableTimer.Delta * Speed * SpeedFactor * 0.5f));
            }
            else
            {
                move(Math.Abs(RewindableTimer.Delta * Speed * SpeedFactor));
            }

            Pivot.localPosition = transform.worldToLocalMatrix.MultiplyVector(Offset.GetOutaXZ() * OffsetFactor);
        }
    }

    public void Stun(float duration)
    {
        _stunDuration = duration;
    }
    public void Slow(float duration)
    {
        _slowDuration = duration;
    }

    private void OnDestroy()
    {
        Followers.Instance?.Deregister(this);
    }

    private void move(float movement)
    {
        if (Path == null)
            return;

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
