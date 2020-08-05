using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyableUI : MonoBehaviour
{
    public Buyable Buyable;

    public Image Image;
    public TMPro.TextMeshProUGUI CostText;
    public TMPro.TextMeshProUGUI NameText;
    public TMPro.TextMeshProUGUI BigNameText;
    public Button Button;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ApplyBuyable()
    {
        Image.sprite = Buyable.Icon;

        if (Buyable.Cost > 0)
        {
            CostText.text = Buyable.Cost.ToString();
            NameText.text = Buyable.Name;
            BigNameText.text = string.Empty;
        }
        else
        {
            CostText.text = string.Empty;
            NameText.text = string.Empty;
            BigNameText.text = Buyable.Name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ApplyBuyable();
        Button.gameObject.SetActive(Buyable.CanBuy);
    }

    public void Buy()
    {
        if (!Buyable.CanBuy)
            return;
        Buyable.Buy();
    }
}
