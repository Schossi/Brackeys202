using System.Collections.Generic;
using UnityEngine;

public static class GamePrefs
{
    private static List<string> initNames = new List<string>()
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

    private static int? _progress;
    public static int Progress
    {
        get
        {
            if (!_progress.HasValue)
                _progress = PlayerPrefs.GetInt("rezardprogress");
            return _progress.Value;
        }
        set
        {
            if (!_progress.HasValue)
                _progress = PlayerPrefs.GetInt("rezardprogress");
            if (_progress.Value >= value)
                return;
            _progress = value;
            PlayerPrefs.SetInt("rezardprogress", value);
        }
    }

    private static string _username = null;
    public static string Username
    {
        get
        {
            if (_username == null)
            {
                _username = PlayerPrefs.GetString("rezardname");
                if (string.IsNullOrWhiteSpace(_username))
                    Username = initNames[Random.Range(0, initNames.Count - 1)];
            }
            return _username;
        }
        set
        {
            _username = value;
            PlayerPrefs.SetString("rezardname", value);
        }
    }
}
