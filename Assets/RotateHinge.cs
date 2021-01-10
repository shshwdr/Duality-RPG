using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHinge : MonoBehaviour
{
    float startSpeed;
    HingeJoint2D hingeJoint;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
    }
    private void Update()
    {
        if ((hingeJoint.limitState == JointLimitState2D.LowerLimit&& hingeJoint.motor.motorSpeed < 0) ||
            (hingeJoint.limitState == JointLimitState2D.UpperLimit && hingeJoint.motor.motorSpeed > 0))
        {
            startSpeed *= -1;
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = -hingeJoint.motor.motorSpeed;
            hingeJoint.motor = motor;
        }
    }

}
