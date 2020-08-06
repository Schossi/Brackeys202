using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buyable/Retry")]
public class BuyableRetry : Buyable
{
    public override bool CanBuy => GameManager.Instance.State == GameState.Won || GameManager.Instance.State == GameState.Lost;
    public override int Cost => 0;

    public override void Buy()
    {
        GameManager.Instance.Retry();
    }
}
