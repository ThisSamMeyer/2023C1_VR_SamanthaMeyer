using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReleaseButton : MonoBehaviour
{
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float threshHold;
    public float force = 10f;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    // Start is called before the first frame update
    void Start()
    {
        // Ignore collisions between the button top and bottom
        Physics.IgnoreCollision(GetComponent<Collider>(), buttonTop.GetComponent<Collider>());

        // find the resting distance between the top and bottom of the button, unpressed
        upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // only allow button to move up and down
        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.eulerAngles = new Vector3(0, 0, 0);

        // set the button to default to upper limit
        if (buttonTop.localPosition.y >= 0)
        {
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        }
        else
        {
            buttonTop.GetComponent<Rigidbody>().AddForce(buttonTop.transform.up * force * Time.fixedDeltaTime);
        }

        // prevent button from going past the lower limit
        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
        {
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);
        }

        // find if the button it pressed or not
        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
    }
}
