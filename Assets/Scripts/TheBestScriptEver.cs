using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBestScriptEver : MonoBehaviour
{
    public Rigidbody rb;

    // Awake is called right before the Start function
    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 launchVelocity = CalculateLaunchVelocity(Vector3.zero);
        rb.AddForce(launchVelocity);

        // this line does the same thing as the previous two lines
        rb.AddForce(CalculateLaunchVelocity(Vector3.zero));
    }

    Vector3 CalculateLaunchVelocity(Vector3 targetPosition)
    {
        // do a bunch of calculations
        return Vector3.forward * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called at a fixed interval
    private void FixedUpdate()
    {
        
    }

    // LateUpdate is called every frame right after the Update function
    private void LateUpdate()
    {
        
    }

    // OnDestroy is called when the associated GameObject is destroyed
    private void OnDestroy()
    {
        
    }

    // OnTriggerEnter is called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
