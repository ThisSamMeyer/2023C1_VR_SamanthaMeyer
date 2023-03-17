using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotElbowTwoMovement : MonoBehaviour
{
    public GameObject lever;
    public GameObject robotElbow;

    HingeJoint elbowHinge;
    HingeJoint leverHinge;

    JointSpring elbowSpring;

    float leverAngle;
    public float elbowAngle;

    void Start()
    {
        elbowHinge = robotElbow.GetComponent<HingeJoint>();
        leverHinge = lever.GetComponent<HingeJoint>();

        elbowSpring = elbowHinge.spring;
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

        if (leverAngle > 1)
        {
            ExtendElbow(angleFraction);
        }
        else if (leverAngle < -1)
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
        elbowSpring.targetPosition = elbowHinge.limits.max;
        elbowSpring.spring = speed * 80;
        elbowHinge.spring = elbowSpring;
    }

    public void RetractElbow(float speed)
    {
        elbowSpring.targetPosition = elbowHinge.limits.min;
        elbowSpring.spring = speed * 80;
        elbowHinge.spring = elbowSpring;
    }
}
