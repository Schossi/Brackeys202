using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buyable/Start")]
public class BuyableStart : Buyable
{
    public override bool CanBuy => GameManager.Instance.State == GameState.Buy && Basecamp.Instance.HasRecorder;
    public override int Cost => 0;

    public override void Buy()
    {
        GameManager.Instance.StartRound();
    }
}
