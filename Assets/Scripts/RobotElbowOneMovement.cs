using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotElbowOneMovement : MonoBehaviour
{
    public GameObject lever;
    public GameObject robotElbow;

    HingeJoint elbowHinge;
    HingeJoint leverHinge;

    JointMotor elbowMotor;

    float leverAngle;
    public float elbowAngle;

    void Start()
    {
        elbowHinge = robotElbow.GetComponent<HingeJoint>();
        leverHinge = lever.GetComponent<HingeJoint>();

        elbowMotor = elbowHinge.motor;
    }

    void Update()
    {
        leverAngle = leverHinge.angle;
        elbowAngle = elbowHinge.angle;
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
            ExtendElbow(angleFraction);
        }
        else if(leverAngle < -1)
        {
            RetractElbow(angleFraction);
        }
        else
        {
            elbowHinge.useMotor = false;
        }
    }

    public void ExtendElbow(float speed)
    {
        elbowHinge.useMotor = true;
        elbowMotor.targetVelocity = 100 * speed;
        elbowMotor.force = 100 * speed;
        elbowHinge.motor = elbowMotor;
    }

    public void RetractElbow(float speed)
    {
        elbowHinge.useMotor = true;
        elbowMotor.targetVelocity = -100 * speed;
        elbowMotor.force = 100 * speed;
        elbowHinge.motor = elbowMotor;
    }
}
