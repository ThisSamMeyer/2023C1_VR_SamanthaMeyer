using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndReleaseTrigger : MonoBehaviour
{
    public GameObject grabTrigger;
    public GameObject robotMagnet;
    public Material triggerOnMat;
    public Material triggerOffMat;
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
            grabTrigger.GetComponentInChildren<MeshRenderer>().material = triggerOffMat;
        }


        if (collidedObject && (collidedObject.CompareTag("RegularCube") || collidedObject.CompareTag("CompanionCube")))
        {
            // make lever light up when magnet has collided with an object
            grabTrigger.GetComponentInChildren<MeshRenderer>().material = triggerOnMat;

            // grab object when lever is pulled
            if (grabEnabled && !collidedObject.GetComponent<FixedJoint>())
            {
                FixedJoint cubeJoint = collidedObject.AddComponent<FixedJoint>();
                cubeJoint.connectedBody = robotMagnet.GetComponent<Rigidbody>();
                collidedObject.GetComponent<Rigidbody>().useGravity = false;
            }
            if(!grabEnabled && collidedObject.GetComponent<FixedJoint>())
            {
                collidedObject.GetComponent<Rigidbody>().useGravity = true;
                Destroy(collidedObject.GetComponent<FixedJoint>());
                collidedObject = null;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("we hit something");

        collidedObject = collision.gameObject;
    }
}
