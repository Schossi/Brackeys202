using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.Rendering;

public class AttackerUI : MonoBehaviour
{
    public static AttackerUI Instance;

    public Attacker Attacker;

    public RectTransform Container;
    public RectTransform NormalArea;
    public RectTransform PerfectArea;
    public RectTransform Current;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Attacker == null)
            Container.gameObject.SetActive(false);
        else
            Container.gameObject.SetActive(true);

        float currentFactor = 0f;
        float minFactor = 0f;
        float perfectFactorLeft = 0f;
        float perfectFactorRight = 0f;

        switch (Attacker)
        {
            case DrawAttacker draw:

                if (draw.Config.IsCharger)
                {
                    float max = draw.Config.PerfectTime;

                    currentFactor = Math.Min(draw.DrawTime / max, 1f);
                    minFactor = draw.Config.MinTime / max;
                    perfectFactorLeft = (draw.Config.PerfectTime - draw.Config.Tolerance) / max;
                    perfectFactorRight = 0;
                }
                else
                {
                    float max = draw.Config.PerfectTime + draw.Config.Tolerance * 3;

                    currentFactor = Math.Min(draw.DrawTime / max, 1f);
                    minFactor = draw.Config.MinTime / max;
                    perfectFactorLeft = (draw.Config.PerfectTime - draw.Config.Tolerance) / max;
                    perfectFactorRight = 1 - (draw.Config.PerfectTime + draw.Config.Tolerance) / max;
                }
                break;
        }

        float absolute = Container.rect.width;

        Current.anchoredPosition = new Vector2(currentFactor * absolute, 0f);
        NormalArea.SetLeft(minFactor * absolute);
        PerfectArea.SetLeft(perfectFactorLeft * absolute);
        PerfectArea.SetRight(perfectFactorRight * absolute);
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
