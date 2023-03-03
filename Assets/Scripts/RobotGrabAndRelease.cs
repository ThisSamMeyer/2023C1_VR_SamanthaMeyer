using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGrabAndRelease : MonoBehaviour
{
    public GameObject grabTrigger;
    public GameObject robotMagnet;
    HingeJoint grabTriggerHinge;
    GameObject collidedObject;
    bool grabEnabled;
    public float threshHold;

    void Start()
    {
        grabTriggerHinge = grabTrigger.GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (grabTriggerHinge.angle >= grabTriggerHinge.limits.max - threshHold)
        {
            grabEnabled = true;
        }
        else
        {
            grabEnabled = false;
        }

        if (collidedObject.CompareTag("RegularCube") || collidedObject.CompareTag("CompanionCube"))
        {
            // make release lever light up

            if (grabEnabled && !collidedObject.GetComponent<FixedJoint>())
            {
                FixedJoint cubeJoint = collidedObject.AddComponent<FixedJoint>();
                cubeJoint.connectedBody = robotMagnet.GetComponent<Rigidbody>();
            }
            if(!grabEnabled && collidedObject.GetComponent<FixedJoint>())
            {
                Destroy(collidedObject.GetComponent<FixedJoint>());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("we hit something");

        collidedObject = collision.gameObject;
    }
}
