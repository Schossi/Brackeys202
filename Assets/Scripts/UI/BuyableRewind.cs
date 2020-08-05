using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buyable/Rewind")]
public class BuyableRewind : Buyable
{
    public override bool CanBuy => GameManager.Instance.State == GameState.End;
    public override int Cost => Basecamp.Instance.RewindCost;

    public override void Buy()
    {
        GameManager.Instance.Rewind();
    }
}
