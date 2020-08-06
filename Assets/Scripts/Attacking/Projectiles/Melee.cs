using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float MaxDuration;
    public int Damage;
    public Collider Collider;

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
    }

    protected virtual void hurt(IGetHurt hurter)
    {
        hurter.Hurt(Damage);
    }
}
