using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeTriggered : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool isTurnedOn = true;

    public virtual void turnOn()
    {
        Debug.Log("turn on");
        isTurnedOn = true;
    }

    public virtual void turnOff()
    {
        isTurnedOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
