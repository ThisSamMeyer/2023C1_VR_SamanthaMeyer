using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCylinder : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("that was the player!");
        }
    }

}
