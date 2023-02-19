using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowTwoRotation : MonoBehaviour
{
    public GameObject leverTwo;
    public GameObject elbowTwo;

    HingeJoint hingeElbowTwo;
    HingeJoint hingeLeverTwo;
    JointMotor motorElbowTwo;

    public float angleLeverTwo;
    public float angleElbowTwo;

    float lastFrameLeverAngle;

    // Start is called before the first frame update
    void Start()
    {
        hingeElbowTwo = elbowTwo.GetComponent<HingeJoint>();
        hingeLeverTwo = leverTwo.GetComponent<HingeJoint>();
        motorElbowTwo = hingeElbowTwo.motor;
    }

    // Update is called once per frame
    void Update()
    {
        angleLeverTwo = hingeLeverTwo.angle;
        angleElbowTwo = hingeElbowTwo.angle;

        float diffAngleLeverTwo = hingeLeverTwo.angle - lastFrameLeverAngle;

        motorElbowTwo.targetVelocity = hingeLeverTwo.angle / 10;
        motorElbowTwo.force = 100;
        motorElbowTwo.freeSpin = false;
        hingeElbowTwo.motor = motorElbowTwo;
        hingeElbowTwo.useMotor = true;

/*        if (angleLeverTwo > 10 || angleLeverTwo < -10)
        {
            hingeElbowTwo.useMotor = true;
            motorElbowTwo.force = 100;
            motorElbowTwo.targetVelocity = angleLeverTwo / 2;
            motorElbowTwo.freeSpin = false;
            hingeElbowTwo.motor = motorElbowTwo;
        }
        else
        {
            hingeElbowTwo.useMotor = true;
            motorElbowTwo.targetVelocity = 0;
            motorElbowTwo.force = 100;
            motorElbowTwo.freeSpin = false;
            hingeElbowTwo.motor = motorElbowTwo;
            // hingeElbowTwo.useMotor = false;
        }
*/
        lastFrameLeverAngle = hingeLeverTwo.angle;
    }
}
