using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class IceTriger : BeTriggered
{
    SpriteShapeController shape;
    IceGround iceGround;
    // Start is called before the first frame update
    void Start()
    {
        shape = GetComponent<SpriteShapeController>();
        iceGround = GetComponent<IceGround>();
        shape.enabled = false;
        iceGround.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void turnOn()
    {
        base.turnOn();
        shape.enabled = true;
        iceGround.enabled = true;
        Debug.Log("ice turned on");
    }

    public override void turnOff()
    {
        base.turnOff();
    }
}
