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

    public float angleLeverOne;
    public float angleElbowOne;

    // Start is called before the first frame update
    void Start()
    {
        hingeElbowOne = elbowOne.GetComponent<HingeJoint>();
        hingeLeverOne = leverOne.GetComponent<HingeJoint>();
        springElbowOne = hingeElbowOne.spring;
    }

    // Update is called once per frame
    void Update()
    {
        angleLeverOne = hingeLeverOne.angle;
        angleElbowOne = hingeElbowOne.angle;
        float angleFraction;

        if(angleLeverOne < 0)
        {
            angleFraction = angleLeverOne / hingeLeverOne.limits.min;
        }
        else
        {
            angleFraction = angleLeverOne / hingeLeverOne.limits.max;
        }

        if (angleLeverOne > 1 || angleLeverOne < -1)
        {
            springElbowOne.targetPosition = angleElbowOne + angleLeverOne;
            springElbowOne.spring = angleFraction * 100;
            hingeElbowOne.spring = springElbowOne;
        }

    }
}
