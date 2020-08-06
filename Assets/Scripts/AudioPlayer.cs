using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    public AudioSource HitSound;
    public AudioSource SummonSound;

    private void Awake()
    {
        Instance = this;
    }

    public static void Hit() => Instance.HitSound.Play();
    public static void Summon() => Instance.SummonSound.Play();
}
