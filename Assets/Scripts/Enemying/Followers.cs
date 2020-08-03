using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Followers : MonoBehaviour
{
    public static Followers Instance { get; private set; }

    public event EventHandler Finished;

    private List<Follower> _followers = new List<Follower>();

    private void Awake()
    {
        Instance = this;
    }

    public void DestroyFollowers()
    {
        for (int i = _followers.Count - 1; i >= 0; i--)
        {
            Destroy(_followers[i].gameObject);
        }
    }

    public void Register(Follower follower)
    {
        follower.Finished += follower_Finished;
        _followers.Add(follower);
    }

    public void Deregister(Follower follower)
    {
        follower.Finished -= follower_Finished;
        _followers.Remove(follower);
    }

    private void follower_Finished(object sender, EventArgs e)
    {
        Finished?.Invoke(sender, e);
    }
}
