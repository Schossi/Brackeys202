using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMPro.TMP_InputField NameInput;

    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;

    public Transform Camera;
    public Transform CameraWinner;

    // Start is called before the first frame update
    void Start()
    {
        NameInput.text = GamePrefs.Username;
        NameInput.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<string>(s => GamePrefs.Username = s));

        var progress = GamePrefs.Progress;

        Stage2.SetActive(progress > 0);
        Stage3.SetActive(progress > 1);

        if (progress > 2)
            Camera.position = CameraWinner.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadStage(int stage)
    {
        SceneManager.LoadScene("Stage" + stage);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ToggleFullscreen()
    {
        if (Screen.fullScreenMode == FullScreenMode.Windowed)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.SetResolution(1200, 800, false);
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}