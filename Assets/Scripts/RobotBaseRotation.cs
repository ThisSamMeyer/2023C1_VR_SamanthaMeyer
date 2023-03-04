using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBaseRotation : MonoBehaviour
{
    public GameObject lever;
    public GameObject armBase;

    HingeJoint baseHinge;
    HingeJoint leverHinge;
    JointSpring baseSpring;

    public float leverAngle;
    public float baseAngle;

    // Start is called before the first frame update
    void Start()
    {
        leverHinge = lever.GetComponent<HingeJoint>();
        baseHinge = armBase.GetComponent<HingeJoint>();
        baseSpring = baseHinge.spring;
    }

    // Update is called once per frame
    void Update()
    {
        leverAngle = leverHinge.angle;
        baseAngle = baseHinge.angle;

        float angleFraction;

        if (leverAngle < 0)
        {
            angleFraction = leverAngle / leverHinge.limits.min;
        }
        else
        {
            angleFraction = leverAngle / leverHinge.limits.max;
        }

        if(leverAngle > 1 || leverAngle < -1)
        {
            baseSpring.targetPosition = baseAngle + leverAngle;
            baseSpring.spring = angleFraction * 150;
            baseHinge.spring = baseSpring;
        }
    }
}
