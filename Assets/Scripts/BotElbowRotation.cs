using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotElbowRotation : MonoBehaviour
{
    // Lever One declarations
    public GameObject leverOne;     // lever
    HingeJoint hingeLeverOne;       // leverHinge
    public float angleLeverOne;     // leverAngle

    // Lever Two declarations
    public GameObject leverTwo;     // lever
    HingeJoint hingeLeverTwo;       // leverHinge
    public float angleLeverTwo;     //leverAngle

    // Elbow One declarations
    public GameObject elbowOne;     // botElbowOne
    HingeJoint hingeElbowOne;       // botHinge
    JointMotor motorElbowOne;       // botMotor
    public float angleElbowOne;     // botAngle

    // Elbow Two declarations
    public GameObject elbowTwo;     // botElbowOne*
    HingeJoint hingeElbowTwo;       // botHinge
    JointMotor motorElbowTwo;       // botMotor
    public float angleElbowTwo;     //botAngle


    void Start()
    {
        // Assign bot elbow hinges
        hingeElbowOne = elbowOne.GetComponent<HingeJoint>();
        hingeElbowTwo = elbowTwo.GetComponent<HingeJoint>();

        // Assign controller lever hinges
        hingeLeverOne = leverOne.GetComponent<HingeJoint>();
        hingeLeverTwo = leverTwo.GetComponent<HingeJoint>();

        // Assign bot elbow hinge motors
        motorElbowOne = hingeElbowOne.motor;
        motorElbowTwo = hingeElbowTwo.motor;
    }


    void Update()
    {
        // Assign angle values to all hinges
        angleLeverOne = hingeLeverOne.angle;
        angleLeverTwo = hingeLeverTwo.angle;
        angleElbowOne = hingeElbowOne.angle;
        angleElbowTwo = hingeElbowTwo.angle;

        // Rotate Elbow One if Lever One moves past 10 degrees from 0
        if(angleLeverOne > 10 || angleLeverOne < -10)
        {
            hingeElbowOne.useMotor = true;
            motorElbowOne.force = 150;
            motorElbowOne.targetVelocity = angleLeverOne / 2;
            motorElbowOne.freeSpin = false;
            hingeElbowOne.motor = motorElbowOne;
        }
        else
        {
            motorElbowOne.force = 200;
            motorElbowOne.targetVelocity = 0;
            motorElbowOne.freeSpin = false;
            hingeElbowOne.motor = motorElbowOne;
            hingeElbowOne.useMotor = true;
        }

        // Rotate Elbow Two if Lever Two moves past 10 degrees from 0
        if (angleLeverTwo > 10 || angleLeverTwo < -10)
        {
            hingeElbowTwo.useMotor = true;
            motorElbowTwo.force = 150;
            motorElbowTwo.targetVelocity = angleLeverTwo / 2;
            motorElbowTwo.freeSpin = false;
            hingeElbowTwo.motor = motorElbowTwo;
        }
        else
        {
            motorElbowTwo.force = 200;
            motorElbowTwo.targetVelocity = 0;
            motorElbowTwo.freeSpin = false;
            hingeElbowTwo.motor = motorElbowTwo;
            hingeElbowTwo.useMotor = true;
        }
    }
}
