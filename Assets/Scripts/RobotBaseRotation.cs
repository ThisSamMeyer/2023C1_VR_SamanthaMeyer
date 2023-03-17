using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBaseRotation : MonoBehaviour
{
    public GameObject lever;
    public GameObject robotBase;

    HingeJoint baseHinge;
    HingeJoint leverHinge;
    JointMotor baseMotor;

    public float leverAngle;

    void Start()
    {
        leverHinge = lever.GetComponent<HingeJoint>();
        baseHinge = robotBase.GetComponent<HingeJoint>();
        baseMotor = baseHinge.motor;
    }

    void Update()
    {
        leverAngle = leverHinge.angle;
        float angleFraction;

        if (leverAngle < 0)
        {
            angleFraction = leverAngle / leverHinge.limits.min;
        }
        else
        {
            angleFraction = leverAngle / leverHinge.limits.max;
        }

        if(leverAngle > 1)
        {
            RotateClockwise(angleFraction);
        }
        else if(leverAngle < -1)
        {
            RotateCounterClockwise(angleFraction);
        }
        else
        {
            baseHinge.useMotor = false;
        }
    }

    public void RotateClockwise(float speed)
    {
        baseMotor.targetVelocity = 100 * speed;
        baseMotor.force = 100 * speed;
        baseHinge.motor = baseMotor;
        baseHinge.useMotor = true;
    }

    public void RotateCounterClockwise(float speed)
    {
        baseMotor.targetVelocity = -100 * speed;
        baseMotor.force = 100 * speed;
        baseHinge.motor = baseMotor;
        baseHinge.useMotor = true;
    }
}
