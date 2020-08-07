using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buyable/Next")]
public class BuyableNext : Buyable
{
    public override bool CanBuy => GameManager.Instance.State == GameState.Won;
    public override int Cost => 0;

    public override void Buy()
    {
        GameManager.Instance.Next();
    }
}
