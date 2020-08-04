using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMana : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var position = Cameraer.Instance.GetMousePosition() + new Vector3(0f, 1f, 0f);
            var amount = Random.Range(10f, 100f);

            Basecamp.SpawnMana(position, amount);
        }
    }
}
