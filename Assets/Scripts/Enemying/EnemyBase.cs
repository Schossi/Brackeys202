using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyBase : MonoBehaviour,IGetHurt
{
    public Animator Animator;
    public float Health;

    private void Awake()
    {
        Enemies.Instance.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Enemies.Instance.Deregister(this);
    }

    public void Hurt(float amount)
    {
        Health -= amount;
        if (Health <= 0)
            die();
        else
            Animator.SetTrigger("Hit");
    }

    protected virtual void die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
