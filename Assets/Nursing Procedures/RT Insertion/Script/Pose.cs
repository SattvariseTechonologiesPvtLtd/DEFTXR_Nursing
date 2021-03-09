using UnityEngine;
using System.Collections;
using OculusSampleFramework;

public class Pose : MonoBehaviour
{
    public Transform handposR;
    public Transform handposL;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = handposR.position;
        this.gameObject.transform.position = handposL.position;
    }
}
