using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSlot : MonoBehaviour
{
    public GameObject Unit;
    public GameObject Eye;

    public bool HasUnit => Unit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Eye.SetActive(HasUnit);
    }
}
