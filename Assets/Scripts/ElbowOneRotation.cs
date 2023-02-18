using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowOneRotation : MonoBehaviour
{
    public GameObject lever;
    public GameObject botElbowOne;

    HingeJoint botHinge;
    HingeJoint leverHinge;
    JointMotor botMotor;

    public float leverAngle;
    public float botAngle;

    // Start is called before the first frame update
    void Start()
    {
        botHinge = botElbowOne.GetComponent<HingeJoint>();
        leverHinge = lever.GetComponent<HingeJoint>();
        botMotor = botHinge.motor;
    }

    // Update is called once per frame
    void Update()
    {
        leverAngle = leverHinge.angle;
        botAngle = botHinge.angle;

        if(leverAngle > 10 || leverAngle < -10)
        {
            botHinge.useMotor = true;
            botMotor.force = 100;
            botMotor.targetVelocity = leverAngle / 2;
            botMotor.freeSpin = false;
            botHinge.motor = botMotor;
        }
        else
        {
            botMotor.force = 200;
            botMotor.targetVelocity = 0;
            botMotor.freeSpin = false;
            botHinge.motor = botMotor;
            botHinge.useMotor = false;
        }

        // Debug.Log("Elbow_01 Motor Force: " + botMotor.force);
    }
}
