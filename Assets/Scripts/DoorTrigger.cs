using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    ButtonTrigger buttonTrigger;

    public GameObject button;
    GameObject doorOne;
    GameObject doorTwo;

    Vector3 openPosOne;
    Vector3 openPosTwo;
    Vector3 startPosOne;
    Vector3 startPosTwo;

    public float doorSpeed = 10f;

    private void Awake()
    {
        buttonTrigger = button.GetComponent<ButtonTrigger>();
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
        openPosOne = new Vector3(startPosOne.x - 1, startPosOne.y, startPosOne.z);
        openPosTwo = new Vector3(startPosTwo.x + 1, startPosTwo.y, startPosTwo.z);
    }

    void Update()
    {
        if (buttonTrigger.isPressed)
        {
            doorOne.transform.position = Vector3.MoveTowards(doorOne.transform.position, openPosOne, doorSpeed * Time.deltaTime);
            doorTwo.transform.position = Vector3.MoveTowards(doorTwo.transform.position, openPosTwo, doorSpeed * Time.deltaTime);
        }
        if (!buttonTrigger.isPressed)
        {
            doorOne.transform.position = Vector3.MoveTowards(doorOne.transform.position, startPosOne, doorSpeed * Time.deltaTime);
            doorTwo.transform.position = Vector3.MoveTowards(doorTwo.transform.position, startPosTwo, doorSpeed * Time.deltaTime);

        }
    }
}
