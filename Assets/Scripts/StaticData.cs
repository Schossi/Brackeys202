using System.Collections.Generic;
using UnityEngine;

public class StaticData
{
    // keep constructor private
    private StaticData()
    {
        List<string> initNames = new List<string>()
        {
            "Hans",
            "Franz",
            "Sepp",
            "Karl",
            "Susi",
            "Heli",
            "Christl",
            "Ulli"
        };
        
#if DEBUG
        Username = initNames[Random.Range(0, initNames.Count - 1)];
#else
        Username = string.Empty;
#endif
    }

    static private StaticData _instance;
    static public StaticData Instance
    {
        get
        {
            if (_instance == null)
                _instance = new StaticData();
            return _instance;
        }
    }

    public string Username;
}