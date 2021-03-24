using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBack : MonoBehaviour
{
    public GameObject floorplane;
    public GameObject equipment;
    private Vector3 originalposition;
    private Quaternion originalrotation;
    // Start is called before the first frame update
    void Start()
    {

        originalposition = equipment.gameObject.transform.position;
        originalrotation = equipment.gameObject.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == floorplane.name)
        {
            equipment.gameObject.transform.position = originalposition;
            equipment.gameObject.transform.rotation = originalrotation;
        }
    }
}