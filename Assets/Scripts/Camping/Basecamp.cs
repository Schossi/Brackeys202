using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class Basecamp : MonoBehaviour
{
    public static Basecamp Instance { get; private set; }

    public Mana ManaPrefab;
    public float Mana;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var mana = other.gameObject.GetComponent<Mana>();
        if (mana)
        {
            Mana += mana.Value;
            Destroy(mana.gameObject);
        }
    }

    public static void SpawnMana(Vector3 position, float amount)
    {
        while (amount > 0f)
        {
            var mana = Instantiate(Instance.ManaPrefab, position, Quaternion.identity);
            mana.Target = Instance.transform;
            mana.Value = Math.Min(10f, amount);

            amount -= 10f;
        }
    }
}
