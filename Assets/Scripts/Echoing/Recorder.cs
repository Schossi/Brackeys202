using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public Replayer ReplayPrefab;
    public Transform Position;
    public Attacker Attacker;

    public Timeline Timeline { get; private set; }

    private bool _isRecording;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (_isRecording)
            Timeline.AddPosition(Position.position, Position.rotation);
    }

    public void StartRecording()
    {
        Timeline = new Timeline();
        Attacker.Attacked += Attacker_Attacked;
        _isRecording = true;
    }

    public void StopRecording()
    {
        _isRecording = false;
        Attacker.Attacked -= Attacker_Attacked;
    }

    public Replayer Convert()
    {
        var replayer = Instantiate(ReplayPrefab, transform.position, transform.rotation, transform.parent);
        replayer.Timeline = Timeline;

        Destroy(gameObject);

        return replayer;
    }

    private void Attacker_Attacked(object sender, AttackedArgs e)
    {
        Timeline.AddAttack(RewindableTimer.CurrTime, e.Type, e.Args);
    }
}
