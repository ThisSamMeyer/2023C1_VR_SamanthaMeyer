using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    ButtonTrigger buttonTrigger;
    public GameObject doorButton;
    public GameObject doorPath;
    public GameObject cake;

    GameObject doorOne;
    GameObject doorTwo;

    Vector3 openPosOne;
    Vector3 openPosTwo;
    Vector3 startPosOne;
    Vector3 startPosTwo;

    public Material pathOnMat;
    public Material pathOffMat;

    MeshRenderer[] pathBlockMats;

    public bool doorsOpen;

    float doorSpeed = 0.5f;

    private void Awake()
    {
        buttonTrigger = doorButton.GetComponent<ButtonTrigger>();
    }

    void Start()
    {
        // assign doorOne and doorTwo references
        doorOne = transform.GetChild(0).gameObject;
        doorTwo = transform.GetChild(1).gameObject;

        // set starting positions of each door
        startPosOne = doorOne.transform.position;
        startPosTwo = doorTwo.transform.position;

        // set target postion of each door
        openPosOne = new Vector3(startPosOne.x, startPosOne.y, startPosOne.z + 1);
        openPosTwo = new Vector3(startPosTwo.x, startPosTwo.y, startPosTwo.z - 1);

        pathBlockMats = doorPath.GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
        
        if (buttonTrigger.isPressed && buttonTrigger.isCompanion)
        {
            // open the doors
            doorOne.transform.position = Vector3.MoveTowards(doorOne.transform.position, openPosOne, doorSpeed * Time.deltaTime);
            doorTwo.transform.position = Vector3.MoveTowards(doorTwo.transform.position, openPosTwo, doorSpeed * Time.deltaTime);
            doorsOpen = true;

            // activate cake animation
            cake.GetComponent<Animator>().SetBool("TurnOn", true);

            // turn on trail of lights
            foreach (MeshRenderer mesh in pathBlockMats)
            {
                mesh.material = pathOnMat;
            }
        }
        else
        {
            // close the doors
            doorOne.transform.position = Vector3.MoveTowards(doorOne.transform.position, startPosOne, doorSpeed * Time.deltaTime);
            doorTwo.transform.position = Vector3.MoveTowards(doorTwo.transform.position, startPosTwo, doorSpeed * Time.deltaTime);
            doorsOpen = false;

            // deactivate cake animation
            cake.GetComponent<Animator>().SetBool("TurnOn", false);

            // turn off trail of lights
            foreach (MeshRenderer mesh in pathBlockMats)
            {
                mesh.material = pathOffMat;
            }
        }
    }
}
