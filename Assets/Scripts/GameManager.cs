using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState State { get; private set; } = GameState.Buy;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Followers.Instance.Finished -= follower_Finished;
        RewindableTimer.Instance.Rewinded -= timer_Rewinded;
        Enemies.Instance.Destroyed -= enemy_Destroyed;
        Followers.Instance.Finished += follower_Finished;
        RewindableTimer.Instance.Rewinded += timer_Rewinded;
        Enemies.Instance.Destroyed += enemy_Destroyed;
    }

    private void OnDestroy()
    {
        Followers.Instance.Finished -= follower_Finished;
        RewindableTimer.Instance.Rewinded -= timer_Rewinded;
        Enemies.Instance.Destroyed -= enemy_Destroyed;
    }

    private void timer_Rewinded(object sender, System.EventArgs e)
    {
        setState(GameState.Buy);
    }

    private void follower_Finished(object sender, System.EventArgs e)
    {
        if (Basecamp.Instance.IsFull)
            setState(GameState.Lost);
        else
            setState(GameState.End);
    }

    private void enemy_Destroyed(object sender, System.EventArgs e)
    {
        if (Enemies.Instance.IsEmpty && Spawners.Instance.IsFinished)
        {
            setState(GameState.Won);
        }
    }

    public void StartRound()
    {
        setState(GameState.Play);
    }

    public void Rewind()
    {
        setState(GameState.Rewind);
    }

    private void setState(GameState state)
    {
        State = state;
        switch (state)
        {
            case GameState.Buy:
                BuyingUI.Instance.Show();
                FieldCursor.Instance.DeactivateCursor();

                RewindableTimer.Instance.Stop();

                Enemies.Instance.DestroyEnemies();
                break;
            case GameState.Play:
                BuyingUI.Instance.Hide();
                FieldCursor.Instance.ActivateCursor();

                RewindableTimer.Instance.Play();
                Basecamp.Instance.CurrentRecorder.StartRecording();
                break;
            case GameState.End:
                BuyingUI.Instance.Show();
                FieldCursor.Instance.DeactivateCursor();

                RewindableTimer.Instance.Stop();
                Basecamp.Instance.CurrentRecorder.StopRecording();
                break;
            case GameState.Rewind:
                BuyingUI.Instance.Hide();
                FieldCursor.Instance.DeactivateCursor();

                Basecamp.Instance.ConvertRecorder();

                RewindableTimer.Instance.Rewind(25);
                break;
            case GameState.Won:
                BuyingUI.Instance.Hide();
                FieldCursor.Instance.DeactivateCursor();

                RewindableTimer.Instance.Stop();

                MenuManager.Instance.ShowWon();
                break;
            case GameState.Lost:
                BuyingUI.Instance.Hide();
                FieldCursor.Instance.DeactivateCursor();

                RewindableTimer.Instance.Stop();

                MenuManager.Instance.ShowLost();
                break;
            default:
                break;
        }
    }
}
