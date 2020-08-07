using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOffsetter : MonoBehaviour
{
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        AnimatorStateInfo state = Animator.GetCurrentAnimatorStateInfo(0);//could replace 0 by any other animation layer index
        Animator.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
