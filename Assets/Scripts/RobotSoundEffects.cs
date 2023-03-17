using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSoundEffects : MonoBehaviour
{
    AudioSource servoSound;

    RobotStateManager robotStateManager;

    private void Awake()
    {
        robotStateManager = gameObject.GetComponent<RobotStateManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        servoSound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (robotStateManager.partsEnabled)
        {
            servoSound.Play();
        }
        else
        {
            servoSound.Pause();
        }
    }
}
