using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public Transform Position;
    public Attacker Attacker;

    public Timeline Timeline { get; private set; }

    private bool _isRecording;

    private void Start()
    {
        StartRecording();//debug
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

    private void Attacker_Attacked(object sender, AttackedArgs e)
    {
        Timeline.AddAttack(RewindableTimer.CurrTime, e.Type, e.Args);
    }
}
