using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorPathTrigger : MonoBehaviour
{
    DoorTrigger doorTrigger;
    public GameObject doors;

    public Material pathOnMat;
    public Material pathOffMat;

    MeshRenderer[] pathBlockMats;

    private void Awake()
    {
        doorTrigger = doors.GetComponent<DoorTrigger>();
    }

    // Start is called before the first frame update
    void Start()
    {
        pathBlockMats = gameObject.GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorTrigger.doorsOpen)
        {
            foreach(MeshRenderer mesh in pathBlockMats)
            {
                mesh.material = pathOnMat;
            }
        }
        else
        {
            foreach (MeshRenderer mesh in pathBlockMats)
            {
                mesh.material = pathOffMat;
            }
        }
    }
}
