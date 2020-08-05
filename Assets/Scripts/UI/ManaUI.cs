using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI TextMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh.text = Basecamp.Instance.Mana.ToString();
    }
}
