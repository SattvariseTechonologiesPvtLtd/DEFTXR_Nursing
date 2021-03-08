using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPosition : MonoBehaviour
{
    public GameObject floorPlane;
    public GameObject equipment;
    private Vector3 originalPos;
    private Quaternion originalRotate;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = equipment.gameObject.transform.position;
        originalRotate = equipment.gameObject.transform.rotation;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == floorPlane.name)
        {
            equipment.gameObject.transform.position = originalPos;
            equipment.gameObject.transform.rotation = originalRotate;
        }
    }
}
