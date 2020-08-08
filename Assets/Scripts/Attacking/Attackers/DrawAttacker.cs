using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Jobs;
using UnityEngine;

public class DrawAttacker : Attacker
{
    public DrawConfig Config;
    public AudioSource DrawSound;

    public float DrawTime => _downTime;
    public override bool IsSlowing => _isDown;
    public override bool IsStopping => _recoveryTime > 0f;

    private bool _isDown;
    private bool _isPerfectEntered;
    private float _downTime;
    private float _recoveryTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isDeactivated)
            return;

        _recoveryTime -= Time.deltaTime;

        if (Input.GetButtonDown(InputAxis.ATTACK))
        {
            DrawSound.Play();
            _isDown = true;
            setAnimationDraw(true);
        }

        if (_isDown)
        {
            _downTime += Time.deltaTime;

            if (!_isPerfectEntered && _downTime >= Config.PerfectTime - Config.Tolerance)
            {
                _isPerfectEntered = true;
                AudioPlayer.Perfect();
            }
        }
        else
        {
            _downTime = 0f;
        }

        if (Input.GetButtonUp(InputAxis.ATTACK))
        {
            _isDown = false;
            _isPerfectEntered = false;

            if (DrawTime >= Config.MinTime)
            {
                float multiplier = Math.Min(DrawTime / Config.PerfectTime, 1.0f);
                bool isPerfect;

                if (Config.IsCharger)
                    isPerfect = DrawTime > Config.PerfectTime - Config.Tolerance;
                else
                    isPerfect = Math.Abs(Config.PerfectTime - DrawTime) <= Config.Tolerance;

                Attack(multiplier, isPerfect);
                setAnimationAttack();
                _recoveryTime = Config.Recovery;
            }

            setAnimationDraw(false);
        }

    }

    public override void DeactivateAttacker()
    {
        base.DeactivateAttacker();

        _isDown = false;
        setAnimationDraw(false);
    }
}
