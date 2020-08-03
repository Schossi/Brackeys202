using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replayer : MonoBehaviour
{
    public Transform Position;

    public Timeline Timeline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timeline.GetAttack(EchoTimer.Instance.PreviousTime, EchoTimer.Instance.CurrentTime).Execute();
    }

    private void FixedUpdate()
    {
        Timeline.GetPosition(EchoTimer.Instance.CurrentStep).Apply(Position);
    }
}
