using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesAndReferences : MonoBehaviour
{
    // these variables are public and reference external assets
    public Transform otherObjectTransform;
    public Material usefulMaterial;
    public Camera mainCamera;
    Rigidbody rb;
    public GameObject otherRigidBody;

    // this variable is private
    int numberOfOranges;

    // Start is called before the first frame update
    void Start()
    {
        numberOfOranges = 40;
        mainCamera.backgroundColor = Color.black;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1000);

        rb = otherRigidBody.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 100);
    }

    // Update is called once per frame
    void Update()
    {
        numberOfOranges = numberOfOranges - 1;
        otherObjectTransform.position = otherObjectTransform.position + Vector3.forward;
    }
}
