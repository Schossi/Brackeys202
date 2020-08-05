using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using UnityEngine;

public class Basecamp : MonoBehaviour
{
    public static Basecamp Instance { get; private set; }

    public Mana ManaPrefab;
    public Transform ManaTarget;
    public UnitSlot[] Slots;
    public int RewindCost;
    public int Mana;

    public bool HasRecorder => _currentRecorder != null;
    public bool IsFull => Slots.All(s => s.HasUnit);
    public Recorder CurrentRecorder => _currentRecorder;

    private Recorder _currentRecorder;

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

    public void InstantiateUnit(Recorder prefab, int cost)
    {
        RewindCost += cost;

        var slot = Slots.First(s => !s.HasUnit);
        _currentRecorder = Instantiate(prefab, slot.transform.position, slot.transform.rotation);

        slot.Unit = _currentRecorder.gameObject;
    }

    public void ConvertRecorder()
    {
        var slot = Slots.First(s => s.Unit == _currentRecorder.gameObject);

        slot.Unit = _currentRecorder.Convert().gameObject;
        _currentRecorder = null;
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

    public static void SpawnMana(Vector3 position, int amount)
    {
        while (amount > 0)
        {
            var mana = Instantiate(Instance.ManaPrefab, position, Quaternion.identity);
            mana.Target = Instance.ManaTarget;
            mana.Value = Math.Min(10, amount);

            amount -= 10;
        }
    }
}
