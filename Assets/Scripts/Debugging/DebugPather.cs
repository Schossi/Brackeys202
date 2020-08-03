using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPather : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RewindableTimer.Instance.Rewinded += Instance_Rewinded;
        RewindableTimer.Instance.Play();

        Followers.Instance.Finished += Instance_Finished;
    }

    private void Instance_Rewinded(object sender, System.EventArgs e)
    {
        Followers.Instance.DestroyFollowers();
        RewindableTimer.Instance.Play();
    }

    private void Instance_Finished(object sender, System.EventArgs e)
    {
        RewindableTimer.Instance.Rewind(3);
    }
}
