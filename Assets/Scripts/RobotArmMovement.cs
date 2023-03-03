using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArmMovement : MonoBehaviour
{
    public GameObject controlLever;
    public GameObject robotElbow;

    HingeJoint elbowHinge;
    HingeJoint leverHinge;
    JointSpring elbowSpring;

    public float leverAngle;
    public float elbowAngle;

    // Start is called before the first frame update
    void Start()
    {
        elbowHinge = robotElbow.GetComponent<HingeJoint>();
        leverHinge = controlLever.GetComponent<HingeJoint>();
        elbowSpring = elbowHinge.spring;
    }

    // Update is called once per frame
    void Update()
    {
        leverAngle = leverHinge.angle;
        elbowAngle = elbowHinge.angle;
        float angleFraction;

        if (leverAngle < -0.5)
        {
            angleFraction = leverAngle / leverHinge.limits.min;
            elbowSpring.targetPosition = elbowHinge.limits.min;
            elbowSpring.spring = angleFraction * 50;
            elbowHinge.spring = elbowSpring;
        }
        if (leverAngle > 0.5)
        {
            angleFraction = leverAngle / leverHinge.limits.max;
            elbowSpring.targetPosition = elbowHinge.limits.max;
            elbowSpring.spring = angleFraction * 50;
            elbowHinge.spring = elbowSpring;
        }

        /*
        if (leverAngle > 1)
        {
            elbowSpring.targetPosition = elbowHinge.limits.max;
            elbowSpring.spring = angleFraction * 50;
            elbowHinge.spring = elbowSpring;
        }
        if (leverAngle < -1)
        {
            elbowSpring.targetPosition = elbowHinge.limits.min;
            elbowSpring.spring = angleFraction * 50;
            elbowHinge.spring = elbowSpring;
        }
        */
    }
}
