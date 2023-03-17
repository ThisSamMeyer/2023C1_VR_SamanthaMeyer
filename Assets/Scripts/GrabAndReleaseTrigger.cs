using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndReleaseTrigger : MonoBehaviour
{
    public GameObject grabTrigger;
    public GameObject robotMagnet;
    public Material triggerOnMat;
    public Material triggerOffMat;
    public Material magnetMat;
    HingeJoint grabTriggerHinge;
    GameObject collidedObject;
    bool grabEnabled;
    bool isCube;
    bool prevGrabState;
    public float threshHold;

    void Start()
    {
        grabTriggerHinge = grabTrigger.GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (isCube)
        {
            // lever lights up when magnet is touching a cube
            grabTrigger.GetComponentInChildren<MeshRenderer>().material = triggerOnMat;
            robotMagnet.GetComponent<MeshRenderer>().material = triggerOnMat;

            if (grabTriggerHinge.angle >= grabTriggerHinge.limits.max - threshHold)
            {
                grabEnabled = true;
            }
            else
            {
                grabEnabled = false;
            }
        }
        else
        {
            // lever does not light up when magnet is not touching a cube
            grabTrigger.GetComponentInChildren<MeshRenderer>().material = triggerOffMat;
            robotMagnet.GetComponent<MeshRenderer>().material = magnetMat;
        }

        if (grabEnabled && prevGrabState != grabEnabled)
        {
            prevGrabState = grabEnabled;
            Grab();
        }
        if (!grabEnabled && prevGrabState != grabEnabled)
        {
            prevGrabState = grabEnabled;
            Release();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collidedObject = collision.gameObject;

        if (collision.gameObject.CompareTag("RegularCube") || collision.gameObject.CompareTag("CompanionCube"))
        {
            isCube = true;
        }

        Debug.Log("Collision Enter - isCube: " + isCube);
    }

    private void OnCollisionExit(Collision collision)
    {
        collidedObject = collision.gameObject;

        if (collision.gameObject.CompareTag("RegularCube") || collision.gameObject.CompareTag("CompanionCube"))
        {
            isCube = false;
        }

        Debug.Log("Collision Exit - isCube: " + collision.gameObject);
    }

    private void Grab()
    {
        if (!collidedObject.GetComponent<FixedJoint>())
        {
            FixedJoint cubeJoint = collidedObject.AddComponent<FixedJoint>();
            cubeJoint.connectedBody = robotMagnet.GetComponent<Rigidbody>();
            collidedObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void Release()
    {
        if (collidedObject.GetComponent<FixedJoint>())
        {
            collidedObject.GetComponent<Rigidbody>().useGravity = true;
            Destroy(collidedObject.GetComponent<FixedJoint>());
            collidedObject = null;
        }
    }
}
