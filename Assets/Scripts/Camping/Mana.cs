using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public Transform Target;
    public float Value;

    private float _lifetime;
    private float _speed;
    private Vector3 _startDirection;
    private Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(15f, 20f);
        _startDirection = Random.insideUnitSphere;
        _direction = _startDirection;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * (_speed + _lifetime) * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, 0f), transform.position.z);

        var toTarget = Target.position - transform.position;

        _lifetime += Time.deltaTime;
        _direction = Vector3.Lerp(_startDirection, toTarget.normalized, _lifetime * 2f);
    }
}
