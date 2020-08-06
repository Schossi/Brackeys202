using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Range;
    public int Piercing;
    public int Damage;
    public float Speed;

    private Vector3 _direction;
    private bool _isFalling;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isFalling)
            return;
                
        transform.position += transform.forward * Speed * Time.deltaTime;

        Range -= Time.deltaTime;
        if (Range <= 0f)
            fall();
    }

    protected void fall()
    {
        _isFalling = true;
        Rigidbody.useGravity = true;
        Rigidbody.isKinematic = false;
        Rigidbody.velocity = transform.forward * Speed - transform.up * Speed / 5;
    }

    protected void die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other?.gameObject?.layer == Layers.Ground)
            die();

        if (Piercing < 0)
            return;

        var hurter = other?.attachedRigidbody?.GetComponent<IGetHurt>();
        if (hurter != null)
        {
            hurt(hurter);
        }
    }

    protected virtual void hurt(IGetHurt hurter)
    {
        hurter.Hurt(Damage);
        Piercing--;
        if (Piercing < 0)
            die();
    }
}
