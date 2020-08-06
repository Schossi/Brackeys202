using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarUI : MonoBehaviour
{
    public RectTransform Container;
    public RectTransform Bar;
    public IGetHurt Target;
    public Follower Follower;

    // Update is called once per frame
    void Update()
    {
        Bar.SetRight(Container.rect.width - Container.rect.width * Target.HealthCurrent / Target.HealthMax);

        if (Follower && Follower.Pivot)
            transform.position = Cameraer.Instance.GetScreenPosition(Follower.Pivot.position);
    }
}
