using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    public TMPro.TextMeshProUGUI TextMesh;

    public int CurrentScore = 60000;

    private bool _isCounting;
    private int _maxScore;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _maxScore = CurrentScore;
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh.text = CurrentScore.ToString();
    }

    private void FixedUpdate()
    {
        if (!_isCounting)
            return;

        CurrentScore--;
    }

    public void StartScore()
    {
        _isCounting = true;
    }
    public void StopScore()
    {
        _isCounting = false;
    }
    public void ResetScore()
    {
        CurrentScore = _maxScore;
    }
    public void ShareScore()
    {
        if (CurrentScore <= 0 || string.IsNullOrWhiteSpace(GamePrefs.Username))
            return;

        GlobalstatsIO gs = new GlobalstatsIO();

        Dictionary<string, string> values = new Dictionary<string, string>();
        values.Add("Stage" + GameManager.Instance.Stage, CurrentScore.ToString());

        if (gs.share("", GamePrefs.Username, values))
        {
            // Success
        }
        else
        {
            // An Error occured
        }
    }
}
