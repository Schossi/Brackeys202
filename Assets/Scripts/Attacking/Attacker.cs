using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Attacker : MonoBehaviour
{
    public AttackType AttackType;
    public Animator Animator;

    public virtual bool IsSlowing => false;
    public virtual bool IsStopping => false;

    public event EventHandler<AttackedArgs> Attacked;

    protected bool _isDeactivated;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void DeactivateAttacker()
    {
        _isDeactivated = true;
    }

    public void Attack(float multiplier, bool isPerfect)
    {
        var target = Cameraer.Instance.GetTargetPosition();
        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        var args = new AttackArgs()
        {
            Position = transform.position,
            Rotation = transform.rotation,
            Multiplier = multiplier,
            IsPerfect = isPerfect
        };

        Attacks.Execute(AttackType, args);
        Attacked?.Invoke(this, new AttackedArgs(AttackType, args));
    }

    protected void setAnimationDraw(bool value) => Animator.SetBool("draw", value);
    protected void setAnimationAttack() => Animator.SetTrigger("attack");
}
