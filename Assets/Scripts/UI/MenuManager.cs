using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public GameObject WonPanel;
    public GameObject LostPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowWon()
    {
        WonPanel.SetActive(true);
    }

    public void ShowLost()
    {
        LostPanel.SetActive(true);
    }
}
