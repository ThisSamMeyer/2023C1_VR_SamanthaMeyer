using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowOneRotation : MonoBehaviour
{
    public GameObject leverOne;
    public GameObject elbowOne;

    HingeJoint hingeElbowOne;
    HingeJoint hingeLeverOne;
    JointMotor motorElbowOne;
    JointSpring springElbowOne;

    public float angleLeverOne;
    public float angleElbowOne;

    // Start is called before the first frame update
    void Start()
    {
        hingeElbowOne = elbowOne.GetComponent<HingeJoint>();
        hingeLeverOne = leverOne.GetComponent<HingeJoint>();
        motorElbowOne = hingeElbowOne.motor;
        springElbowOne = hingeElbowOne.spring;
    }

    // Update is called once per frame
    void Update()
    {
        angleLeverOne = hingeLeverOne.angle;
        angleElbowOne = hingeElbowOne.angle;

        if(angleLeverOne > 5 || angleLeverOne < -5)
        {
            springElbowOne.targetPosition = angleElbowOne + angleLeverOne;
            hingeElbowOne.spring = springElbowOne;
        }


/*        motorElbowOne.targetVelocity = hingeLeverOne.angle / 10;
        motorElbowOne.force = 100;
        motorElbowOne.freeSpin = false;
        hingeElbowOne.motor = motorElbowOne;
        hingeElbowOne.useMotor = true;
*/

/*        if(angleLeverOne > 10 || angleLeverOne < -10)
        {
            hingeElbowOne.useMotor = true;
            motorElbowOne.force = 100;
            motorElbowOne.targetVelocity = angleLeverOne / 2;
            motorElbowOne.freeSpin = false;
            hingeElbowOne.motor = motorElbowOne;
        }
        else
        {
            hingeElbowOne.useMotor = true;
            motorElbowOne.targetVelocity = 0;
            motorElbowOne.force = 100;
            motorElbowOne.freeSpin = false;
            hingeElbowOne.motor = motorElbowOne;
            // hingeElbowOne.useMotor = false;
        }
*/
    }
}
