using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    private void OnEnable()
    {
        Followers.Instance.Finished += follower_Finished;
        RewindableTimer.Instance.Rewinded += timer_Rewinded;
        Enemies.Instance.Destroyed += enemy_Destroyed;
    }

    private void OnDisable()
    {
        Followers.Instance.Finished -= follower_Finished;
        RewindableTimer.Instance.Rewinded -= timer_Rewinded;
        Enemies.Instance.Destroyed -= enemy_Destroyed;
    }

    private void timer_Rewinded(object sender, System.EventArgs e)
    {
        showBuy();
    }

    private void follower_Finished(object sender, System.EventArgs e)
    {
        RewindableTimer.Instance.Stop();
        showRewind();
    }

    private void enemy_Destroyed(object sender, System.EventArgs e)
    {
        if (Enemies.Instance.IsEmpty && Spawners.Instance.IsFinished)
            showWin();
    }

    public void StartRound()
    {
        RewindableTimer.Instance.Play();
    }

    public void Rewind()
    {
        RewindableTimer.Instance.Rewind(3);
    }

    private void showRewind()
    {

    }

    private void showBuy()
    {

    }

    private void showWin()
    {

    }

    private void showLose()
    {

    }
}
