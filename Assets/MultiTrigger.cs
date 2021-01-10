using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTrigger : BeTriggered
{
    public List<BeTriggered> beTriggers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void turnOn()
    {
        Debug.Log("multi trigger turn on");
        foreach (BeTriggered tri in beTriggers)
        {
            tri.turnOn();
        }
    }

    public override void turnOff()
    {
        foreach (BeTriggered tri in beTriggers)
        {
            tri.turnOff();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
