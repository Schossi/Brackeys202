using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float MaxDuration;
    public int Damage;
    public Collider Collider;

    public bool Stuns;
    public float StunDuration;

    private float lifetime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime > MaxDuration)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var hurter = other?.attachedRigidbody?.GetComponent<IGetHurt>();
        if (hurter != null)
        {
            hurt(hurter);
        }

        if (Stuns)
        {
            var follower = other?.attachedRigidbody?.GetComponent<Follower>();
            if (follower)
            {
                follower.Stun(StunDuration);
            }
        }
    }

    protected virtual void hurt(IGetHurt hurter)
    {
        hurter.Hurt(Damage);
    }
}
