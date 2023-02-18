using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("was triggered by " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Triggered by a player");
        }
    }
}
