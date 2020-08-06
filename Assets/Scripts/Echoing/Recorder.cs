using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public Replayer ReplayPrefab;
    public Transform Position;
    public Attacker Attacker;
    public Mover Mover;

    public Material ReplayMaterial;
    public SkinnedMeshRenderer Renderer;

    public Timeline Timeline { get; private set; }

    private bool _isRecording;

    private void Start()
    {
    }

    private void Update()
    {
        Mover.IsSlowed = Attacker.IsSlowing;
        Mover.IsStopped = Attacker.IsStopping;
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
        var replayer = gameObject.AddComponent<Replayer>();
        replayer.Animator = Attacker.Animator;
        replayer.Timeline = Timeline;

        var mats = Renderer.materials.ToList();
        mats[0] = ReplayMaterial;
        Renderer.materials = mats.ToArray();

        Destroy(this);
        Destroy(Attacker.gameObject);

        return replayer;
    }

    private void Attacker_Attacked(object sender, AttackedArgs e)
    {
        Timeline.AddAttack(RewindableTimer.CurrTime, e.Type, e.Args);
    }
}
