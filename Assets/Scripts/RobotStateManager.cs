using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateManager : MonoBehaviour
{
    List<GameObject> movingParts;
    List<HingeJoint> hinges;
    List<float> lastFramesAngles;

    int numMovingParts;
    int threshHold;

    // public List<bool> partsEnabled;

    public bool partsEnabled;

    // public static bool wheelsEnabled, baseEnabled, elbowOneEnabled, elbowTwoEnabled;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        numMovingParts = 3;
        threshHold = 1;
        movingParts = new List<GameObject>();
        hinges = new List<HingeJoint>();
        // partsEnabled = new List<bool>();
        lastFramesAngles = new List<float>();

        for(int i = 0; i < numMovingParts; i++)
        {
            movingParts.Add(transform.GetChild(i).gameObject);
            hinges.Add(movingParts[i].GetComponent<HingeJoint>());
            // partsEnabled.Add(false);
            lastFramesAngles.Add(hinges[i].angle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < numMovingParts; i++)
        {
            if(hinges[i].angle > lastFramesAngles[i] + threshHold || hinges[i].angle < lastFramesAngles[i] - threshHold)
            {
                // partsEnabled[i] = true;
                lastFramesAngles[i] = hinges[i].angle;
                Debug.Log("i: " + i + " - enabled: " + partsEnabled);

                partsEnabled = true;
            }
        }
    }
}
