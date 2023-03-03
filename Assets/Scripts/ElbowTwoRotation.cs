using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowTwoRotation : MonoBehaviour
{
    public GameObject leverTwo;
    public GameObject elbowTwo;

    HingeJoint hingeElbowTwo;
    HingeJoint hingeLeverTwo;
    JointSpring springElbowTwo;

    public float angleLeverTwo;
    public float angleElbowTwo;

    // Start is called before the first frame update
    void Start()
    {
        hingeElbowTwo = elbowTwo.GetComponent<HingeJoint>();
        hingeLeverTwo = leverTwo.GetComponent<HingeJoint>();
        springElbowTwo = hingeElbowTwo.spring;
    }

    // Update is called once per frame
    void Update()
    {
        angleLeverTwo = hingeLeverTwo.angle;
        angleElbowTwo = hingeElbowTwo.angle;
        float angleFraction;

        if(angleLeverTwo < 0)
        {
            angleFraction = angleLeverTwo / hingeLeverTwo.limits.min;
        }
        else
        {
            angleFraction = angleLeverTwo / hingeLeverTwo.limits.max;
        }

        if(angleLeverTwo > 1)
        {
            springElbowTwo.targetPosition = hingeElbowTwo.limits.max;
            springElbowTwo.spring = angleFraction * 50;
            hingeElbowTwo.spring = springElbowTwo;
        }
        if(angleLeverTwo < -1)
        {
            springElbowTwo.targetPosition = hingeElbowTwo.limits.min;
            springElbowTwo.spring = angleFraction * 50;
            hingeElbowTwo.spring = springElbowTwo;
        }
    }
}
