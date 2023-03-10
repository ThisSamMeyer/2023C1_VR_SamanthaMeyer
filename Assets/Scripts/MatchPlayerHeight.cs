using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPlayerHeight : MonoBehaviour
{
    public Transform mainCamera;
    public Transform floorReference;
    CapsuleCollider capsule;

    // Start is called before the first frame update
    void Start()
    {
        capsule = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // calculate the height difference between main camera and floor
        float headHeight = mainCamera.position.y - floorReference.position.y;

        // move capsule directly between main camera and floor
        transform.position = mainCamera.position - Vector3.up * headHeight / 2;

        // set capsule height to match head height
        capsule.height = headHeight;
    }
}
