using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap_Back : MonoBehaviour

{
    private Vector3 originalposition;
    private Quaternion originalrotation;
    public GameObject floorplane;
    public GameObject equipment;


    // Start is called before the first frame update
    void Start()
    {
        originalposition = equipment.gameObject.transform.position;
        originalrotation = equipment.gameObject.transform.rotation;
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Inside F");
        if (col.gameObject.name == floorplane.name)
        {
            Debug.Log("Inside IF");
            equipment.gameObject.transform.position = originalposition;
            equipment.gameObject.transform.rotation = originalrotation;
        }
    }


}
