using System;
using System.Linq;
using UnityEngine;

public class Basecamp : MonoBehaviour
{
    public static Basecamp Instance { get; private set; }

    public Animator Animator;
    public Mana ManaPrefab;
    public Transform ManaTarget;
    public UnitSlot[] Slots;
    public int RewindCost;
    public int Mana;

    public bool HasRecorder => CurrentRecorder != null;
    public bool IsFull => Slots.All(s => s.HasUnit);
    public Recorder CurrentRecorder
    {
        get
        {
            return _currentRecorder;
        }
        private set
        {
            if(_currentRecorder?.Attacker!=null)
                _currentRecorder.Attacker.Attacked -= Attacker_Attacked;
            _currentRecorder = value;
            if (_currentRecorder?.Attacker != null)
                _currentRecorder.Attacker.Attacked += Attacker_Attacked;
            AttackerUI.Instance.Attacker = value?.Attacker;
        }
    }

    private void Attacker_Attacked(object sender, AttackedArgs e)
    {

    }

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
        CurrentRecorder = Instantiate(prefab, slot.transform.position, slot.transform.rotation);

        slot.Unit = CurrentRecorder.gameObject;

        Summon();
    }

    public void ConvertRecorder()
    {
        var slot = Slots.First(s => s.Unit == CurrentRecorder.gameObject);

        slot.Unit = CurrentRecorder.Convert().gameObject;
        CurrentRecorder = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        var mana = other.gameObject.GetComponent<Mana>();
        if (mana)
        {
            Mana += mana.Value;
            Destroy(mana.gameObject);
        }

        if (other.gameObject.layer == Layers.Enemy)
        {
            GameManager.Instance.EnemyFinished();
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

    public static void Hit() => Instance?.Animator?.SetTrigger("hit");
    public static void Shoot() => Instance?.Animator?.SetTrigger("shoot");
    public static void Summon() => Instance?.Animator?.SetTrigger("win");
}
