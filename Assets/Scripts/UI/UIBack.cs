using UnityEngine;
using UnityEngine.UI;

public class UIBack : MonoBehaviour
{
    public static UIBack Instance;

    public Image Image;

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
        
    }

    public void Show() => Image.enabled = true;
    public void Hide() => Image.enabled = false;
}
