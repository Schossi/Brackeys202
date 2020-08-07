using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMPro.TMP_InputField NameInput;

    // Start is called before the first frame update
    void Start()
    {
        NameInput.text = StaticData.Instance.Username;
        NameInput.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<string>(s => StaticData.Instance.Username = s));
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
}
