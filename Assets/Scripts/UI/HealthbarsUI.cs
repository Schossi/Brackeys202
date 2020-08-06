using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthbarsUI : MonoBehaviour
{
    public static HealthbarsUI Instance { get; private set; }

    public HealthbarUI Prefab;

    private List<HealthbarUI> _currentBars = new List<HealthbarUI>();

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
        for (int i = _currentBars.Count - 1; i >= 0; i--)
        {
            if (_currentBars[i].Target.HealthCurrent <= 0)
            {
                Destroy(_currentBars[i].gameObject);
                _currentBars.RemoveAt(i);
            }
        }
    }

    public void AddBar(IGetHurt hurt)
    {
        if (_currentBars.Any(b => b.Target == hurt))
            return;

        var bar = Instantiate(Prefab, transform);
        bar.Target = hurt;
        bar.Follower = ((MonoBehaviour)hurt).GetComponent<Follower>();
        _currentBars.Add(bar);
    }

    public void Clear()
    {
        _currentBars.ForEach(b => Destroy(b.gameObject));
        _currentBars.Clear();
    }
}
