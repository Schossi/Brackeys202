using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuyingUI : MonoBehaviour
{
    public static BuyingUI Instance { get; private set; }

    public Buyable[] Buyables;
    public RectTransform GapPrefab;
    public BuyableUI BuyablePrefab;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        string lastGroup = null;
        foreach (var buyable in Buyables)
        {
            if (lastGroup != null && lastGroup != buyable.Group)
                Instantiate(GapPrefab, transform);
            lastGroup = buyable.Group;

            var buyableUI = Instantiate(BuyablePrefab, transform);
            buyableUI.Buyable = buyable;
            buyableUI.ApplyBuyable();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
