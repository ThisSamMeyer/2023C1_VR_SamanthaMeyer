using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDriveControl : MonoBehaviour
{
    public GameObject robot;
    public GameObject robotDirector;
    HingeJoint hinge;
    public float threshHold;
    public Vector3 robotForward;

    // Start is called before the first frame update
    void Start()
    {
        hinge = gameObject.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        robotForward = robotDirector.transform.forward;

        if(hinge.angle > threshHold)
        {
            robot.transform.Translate(robotDirector.transform.forward * Time.deltaTime / 2);
        }

        if(hinge.angle < -threshHold)
        {
            robot.transform.Translate(-robotDirector.transform.forward * Time.deltaTime / 2);
        }

        /*
        if(hinge.angle > threshHold)
        {
            robot.transform.Translate(Vector3.right * Time.deltaTime / 2);
        }
        if(hinge.angle < -threshHold)
        {
            robot.transform.Translate(Vector3.left * Time.deltaTime / 2);
        }
        */
    }
}
