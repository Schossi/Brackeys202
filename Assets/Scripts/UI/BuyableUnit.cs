using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buyable/Unit")]
public class BuyableUnit : Buyable
{
    public int UnitCost;
    public Recorder Prefab;

    public override bool CanBuy => GameManager.Instance.State == GameState.Buy && !Basecamp.Instance.HasRecorder;
    public override int Cost => UnitCost;

    public override void Buy()
    {
        Basecamp.Instance.InstantiateUnit(Prefab, Cost);
        GameManager.Instance.StartRound();
        AudioPlayer.Summon();
    }
}
