using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    ButtonTrigger buttonTrigger;
    public GameObject doorButton;

    public GameObject cake;

    GameObject doorOne;
    GameObject doorTwo;

    Vector3 openPosOne;
    Vector3 openPosTwo;
    Vector3 startPosOne;
    Vector3 startPosTwo;

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
    }

    void Update()
    {
        
        if (buttonTrigger.isPressed && buttonTrigger.isCompanion)
        {
            doorOne.transform.position = Vector3.MoveTowards(doorOne.transform.position, openPosOne, doorSpeed * Time.deltaTime);
            doorTwo.transform.position = Vector3.MoveTowards(doorTwo.transform.position, openPosTwo, doorSpeed * Time.deltaTime);
            doorsOpen = true;
            cake.GetComponent<Animator>().SetBool("TurnOn", true);
        }
        else
        {
            doorOne.transform.position = Vector3.MoveTowards(doorOne.transform.position, startPosOne, doorSpeed * Time.deltaTime);
            doorTwo.transform.position = Vector3.MoveTowards(doorTwo.transform.position, startPosTwo, doorSpeed * Time.deltaTime);
            doorsOpen = false;
            cake.GetComponent<Animator>().SetBool("TurnOn", false);
        }
    }
}
