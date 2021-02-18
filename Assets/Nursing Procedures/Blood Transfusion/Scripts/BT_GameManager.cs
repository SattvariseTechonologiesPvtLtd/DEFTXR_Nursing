using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_GameManager : MonoBehaviour
{
    // Grababble Apparatus
    [SerializeField]
    private GameObject Alcohol_Pads;
    [SerializeField]
    private GameObject Blood_Bag;
    [SerializeField]
    private GameObject Normal_Saline;
    [SerializeField]
    private GameObject Rollar_camp;
    [SerializeField]
    private GameObject Syringe;
    [SerializeField]
    private GameObject Transfusion_Pump;

    // Start is called before the first frame update
    void Start()
    {
        InitializeDefaultData();
    }

    void InitializeDefaultData()
    {
        //Enable Disable All Objects

        // 1) Disable all Box Colliders to avoid getting grabbed.
        Alcohol_Pads.GetComponent<BoxCollider>().enabled = false;
        Blood_Bag.GetComponent<BoxCollider>().enabled = false;
        Normal_Saline.GetComponent<BoxCollider>().enabled = false;
        Rollar_camp.GetComponent<BoxCollider>().enabled = false;
        Syringe.GetComponent<BoxCollider>().enabled = false;
        Transfusion_Pump.GetComponent<BoxCollider>().enabled = false;

        // 2) Disable all Gravity since Box Colliders are off
        Alcohol_Pads.GetComponent<Rigidbody>().useGravity = false;
        Blood_Bag.GetComponent<Rigidbody>().useGravity = false;
        Normal_Saline.GetComponent<Rigidbody>().useGravity = false;
        Rollar_camp.GetComponent<Rigidbody>().useGravity = false;
        Syringe.GetComponent<Rigidbody>().useGravity = false;
        Transfusion_Pump.GetComponent<Rigidbody>().useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
