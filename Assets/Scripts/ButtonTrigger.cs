using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float threshHold;
    public float force = 10f;
    private float upperLowerDiff;

    public bool isPressed;
    public bool isCompanion;
    public bool prevPressedState;

    // public Material buttonOnMat;
    // public Material buttonOffMat;

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
        // find if the button is pressed or not
        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
        // if the state of isPressed changes, call the pressed or released functions
        if (isPressed && prevPressedState != isPressed)
        {
            Pressed();
        }
        if (!isPressed && prevPressedState != isPressed)
        {
            Released();
        }
    }

    private void Pressed()
    {
        prevPressedState = isPressed;
        Debug.Log("PRESSED");
        onPressed.Invoke();
    }

    private void Released()
    {
        prevPressedState = isPressed;
        Debug.Log("RELEASED");
        onReleased.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CompanionCube"))
        {
            isCompanion = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isCompanion = false;
    }
}
