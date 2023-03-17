using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisionHandler : MonoBehaviour
{
    public GameObject companionCube;
    public Transform cubeSpawnPos;

    public GameObject magnet;
    public GameObject grabLever;

    public Material leverOffMat;
    public Material magnetOffMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CompanionCube"))
        {
            Destroy(collision.gameObject);
            _ = Instantiate(companionCube, cubeSpawnPos);
            magnet.GetComponent<MeshRenderer>().material = magnetOffMat;
            grabLever.GetComponent<MeshRenderer>().material = leverOffMat;
        }
    }
}
