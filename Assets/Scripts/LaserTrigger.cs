using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    ButtonTrigger buttonTrigger;
    public GameObject laserButton;

    public GameObject laserPath;
    MeshRenderer[] pathBlockMats;
    public Material pathOnMat;
    public Material pathOffMat;

    public Transform startPoint;
    public Transform endPoint;
    LineRenderer laserLine;


    private void Awake()
    {
        buttonTrigger = laserButton.GetComponent<ButtonTrigger>();
    }

    // Start is called before the first frame update
    void Start()
    {
        laserLine = gameObject.GetComponent<LineRenderer>();
        laserLine.startWidth = 0.04f;

        pathBlockMats = laserPath.GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonTrigger.isPressed && buttonTrigger.isCompanion)
        {
            laserLine.enabled = false;
            foreach (MeshRenderer mesh in pathBlockMats)
            {
                mesh.material = pathOnMat;
            }
        }
        else
        {
            laserLine.enabled = true;
            laserLine.SetPosition(0, startPoint.position);
            laserLine.SetPosition(1, endPoint.position);
        }
    }
}
