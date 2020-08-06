using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IGetHurt
{
    public Animator Animator;
    public int Health;

    public Vector3 WorldPosition => transform ? transform.position : Vector3.zero;
    public int HealthMax => Health;
    public int HealthCurrent => _currentHealth;

    private int _currentHealth;

    private void Awake()
    {
        Enemies.Instance.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        Enemies.Instance?.Deregister(this);
    }

    public void Hurt(int amount)
    {
        AudioPlayer.Hit();
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            die();
        }
        else
        {
            Animator.SetTrigger("hit");
            HealthbarsUI.Instance.AddBar(this);
        }
    }

    protected virtual void die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
