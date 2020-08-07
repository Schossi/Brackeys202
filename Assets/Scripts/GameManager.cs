using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int Stage;
    public GameState State { get; private set; }

    private bool _isOver = false;

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

        setState(GameState.Buy);
    }

    private void OnDestroy()
    {
        Followers.Instance.Finished -= follower_Finished;
        RewindableTimer.Instance.Rewinded -= timer_Rewinded;
        Enemies.Instance.Destroyed -= enemy_Destroyed;
    }

    private void timer_Rewinded(object sender, System.EventArgs e)
    {
        if (_isOver)
            RewindableTimer.Instance.Play();
        else
            setState(GameState.Buy);
    }

    public void EnemyFinished() => follower_Finished(null, EventArgs.Empty);
    private void follower_Finished(object sender, System.EventArgs e)
    {
        if (_isOver)
            RewindableTimer.Instance.Rewind(25);
        else if (Basecamp.Instance.IsFull)
            setState(GameState.Lost);
        else
            setState(GameState.End);
    }

    private void enemy_Destroyed(object sender, System.EventArgs e)
    {
        if (Enemies.Instance.IsEmpty && Spawners.Instance.IsFinished)
        {
            if (_isOver)
                RewindableTimer.Instance.Rewind(25);
            else
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

    public void Retry()
    {
        SceneManager.LoadScene("Stage" + Stage);
    }

    public void Next()
    {
        SceneManager.LoadScene("Stage" + (Stage + 1).ToString());
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }

    private void setState(GameState state)
    {
        State = state;

        if (state == GameState.Play)
        {
            FieldCursor.Instance.ActivateCursor();
            AttackerUI.Instance.Show();

            Score.Instance.ResetScore();
            Score.Instance.StartScore();
        }
        else
        {
            HealthbarsUI.Instance.Clear();
            FieldCursor.Instance.DeactivateCursor();
            AttackerUI.Instance.Hide();
            Basecamp.Instance.CurrentRecorder?.Attacker.DeactivateAttacker();

            Score.Instance.StopScore();
        }

        if (state == GameState.Buy || state == GameState.End || state == GameState.Won || state == GameState.Lost)
        {
            BuyingUI.Instance.Show();
            UIBack.Instance.Show();
        }
        else
        {
            BuyingUI.Instance.Hide();
            UIBack.Instance.Hide();
        }

        switch (state)
        {
            case GameState.Buy:
                RewindableTimer.Instance.Stop();
                Enemies.Instance.DestroyEnemies();
                break;
            case GameState.Play:
                RewindableTimer.Instance.Play();
                Basecamp.Instance.CurrentRecorder.StartRecording();
                break;
            case GameState.End:
                RewindableTimer.Instance.Stop();
                Basecamp.Instance.CurrentRecorder.StopRecording();
                break;
            case GameState.Rewind:
                Basecamp.Instance.ConvertRecorder();
                RewindableTimer.Instance.Rewind(25);
                break;
            case GameState.Won:
                _isOver = true;
                Basecamp.Instance.ConvertRecorder();
                RewindableTimer.Instance.Rewind(25);
                MenuManager.Instance.ShowWon();
                Score.Instance.ShareScore();
                break;
            case GameState.Lost:
                _isOver = true;
                Basecamp.Instance.ConvertRecorder();
                RewindableTimer.Instance.Rewind(25);
                MenuManager.Instance.ShowLost();
                break;
            default:
                break;
        }
    }
}
