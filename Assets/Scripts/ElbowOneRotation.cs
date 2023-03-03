using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowOneRotation : MonoBehaviour
{
    public GameObject leverOne;
    public GameObject elbowOne;

    HingeJoint hingeElbowOne;
    HingeJoint hingeLeverOne;
    JointSpring springElbowOne;
    JointMotor motorElbowOne;

    public float angleLeverOne;
    public float angleElbowOne;

    float startingMinimum = 0f;
    float startingMaximum = 115;

    // Start is called before the first frame update
    void Start()
    {
        hingeElbowOne = elbowOne.GetComponent<HingeJoint>();
        hingeLeverOne = leverOne.GetComponent<HingeJoint>();
        springElbowOne = hingeElbowOne.spring;
        motorElbowOne = hingeElbowOne.motor;
    }

    // Update is called once per frame
    void Update()
    {
        angleLeverOne = hingeLeverOne.angle;
        angleElbowOne = hingeElbowOne.angle;
        float angleFraction = angleLeverOne / (startingMaximum - startingMinimum);

        if (angleLeverOne > 1 || angleLeverOne < -1)
        {
            motorElbowOne.targetVelocity = angleFraction * 100;
            motorElbowOne.force = 500;
            hingeElbowOne.motor = motorElbowOne;
            hingeElbowOne.useMotor = true;
        }
    }
}
