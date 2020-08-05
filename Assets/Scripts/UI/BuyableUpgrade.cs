using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buyable/Upgrade")]
public class BuyableUpgrade : Buyable
{
    public int UpgradeCost;
    
    public override bool CanBuy => GameManager.Instance.State == GameState.Buy;
    public override int Cost => UpgradeCost;

    public override void Buy()
    {
    }
}
