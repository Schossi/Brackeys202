using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRewinder : MonoBehaviour
{
    public Recorder UnitPrefab;
    public Replayer EchoPrefab;

    private Recorder _currentUnit;

    // Start is called before the first frame update
    void Start()
    {
        EchoTimer.Instance.Rewinded += Instance_Rewinded;
        startRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            var echo = Instantiate(EchoPrefab, _currentUnit.Position.position, _currentUnit.Position.rotation);
            echo.Timeline = _currentUnit.Timeline;

            Destroy(_currentUnit.gameObject);
            _currentUnit = null;

            EchoTimer.Instance.Rewind(3);
        }
    }

    private void Instance_Rewinded(object sender, System.EventArgs e) => startRound();

    private void startRound()
    {
        _currentUnit = Instantiate(UnitPrefab);
        EchoTimer.Instance.Play();
    }
}
