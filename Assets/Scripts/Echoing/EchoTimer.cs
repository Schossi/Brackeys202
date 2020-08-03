using UnityEngine;
using System.Collections;
using UnityEngine.Playables;
using System;

public class EchoTimer : MonoBehaviour
{
    public static EchoTimer Instance { get; private set; }
    public int Modifier { get; private set; }

    public float PreviousTime { get; private set; }
    public float CurrentTime { get; private set; }
    public int CurrentStep { get; private set; }

    public event EventHandler Played;
    public event EventHandler Stopped;
    public event EventHandler Rewinded;

    private bool _isPlaying;
    private bool _isRewinding;


    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPlaying)
            return;

        PreviousTime = CurrentTime;
        CurrentTime += Time.deltaTime * Modifier;
    }

    private void FixedUpdate()
    {
        if (!_isPlaying)
            return;

        CurrentStep += Modifier;

        if (_isRewinding && CurrentStep <= 0)
        {
            PreviousTime = 0f;
            CurrentTime = 0f;
            CurrentStep = 0;

            Stop();

            Rewinded?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Play(int multiplier = 1)
    {
        Modifier = multiplier;

        _isPlaying = true;
        _isRewinding = false;

        Played?.Invoke(this, EventArgs.Empty);
    }

    public void Stop()
    {
        _isPlaying = false;
        _isRewinding = false;

        Stopped?.Invoke(this, EventArgs.Empty);
    }

    public void Rewind(int multiplier)
    {
        Modifier = -multiplier;
        _isPlaying = true;
        _isRewinding = true;
    }
}
