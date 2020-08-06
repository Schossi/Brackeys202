using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayer : MonoBehaviour
{
    public Animator Animator;
    public Timeline Timeline;

    // Start is called before the first frame update
    void Start()
    {
        Animator.SetBool("draw", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!RewindableTimer.IsPlaying)
            return;

        if (Timeline.GetAttack(RewindableTimer.PrevTime, RewindableTimer.CurrTime).Execute())
            Animator.SetTrigger("attack");
    }

    private void FixedUpdate()
    {
        Animator.SetFloat("speed", Mathf.Min(1.0f, Timeline.GetPosition(RewindableTimer.CurrStep).Apply(transform).magnitude));
    }
}
