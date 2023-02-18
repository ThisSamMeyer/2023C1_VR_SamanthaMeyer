using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotArmRotation : MonoBehaviour
{
    public GameObject lever;
    public GameObject botElbowOne;

    HingeJoint botHinge;
    HingeJoint leverHinge;
    JointMotor botMotor;

    public float leverAngle;
    public float botAngle;

    public float botVelocity;
    public float botForce;

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

        if(leverAngle > 5 || leverAngle < -5)
        {
            botMotor.force = 150;
            botMotor.targetVelocity = leverAngle;
            botMotor.freeSpin = false;
            botHinge.motor = botMotor;
        }
        else
        {
            botMotor.force = 150;
            botMotor.targetVelocity = 0;
            botMotor.freeSpin = false;
            botHinge.motor = botMotor;
        }
    }
}
