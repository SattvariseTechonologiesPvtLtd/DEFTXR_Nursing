using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_GameManager : MonoBehaviour
{
    // list of the audioclips required
    [SerializeField] private List<AudioClip> intro_VO;

    // Actions referencing Actions to be completed by user
    [SerializeField] private bool[] ActionsCompleted = { false };

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField] private List<GameObject> Guides;

    [SerializeField] private AudioSource audioSource;

    // Model of Patient lying on Bed
    [SerializeField] private GameObject patient;

    private bool grabbedOnce1 = false;
    private bool grabbedOnce2 = false;
    private bool grabbedOnce3 = false;
    private bool grabbedOnce4 = false;

    //Grabbable objects
    [SerializeField] private GameObject Alcohol_Pads;
    [SerializeField] private GameObject Blood_Bag;
    [SerializeField] private GameObject Normal_Saline;
    [SerializeField] private GameObject Roller_Clamp;
    [SerializeField] private GameObject Syringe;
    [SerializeField] private GameObject Volumetric_Pump;
    [SerializeField] private GameObject BloodBag_IVPole;
    [SerializeField] private GameObject NormalSaline_IVPole;



    // Start is called before the first frame update
    void Start()
    {
        InitializeDefaultData();
        StartCoroutine(Introduction());
    }

    //Intro
    IEnumerator Introduction()
    {
        // Introduction
        Debug.Log("Play VO1");
        audioSource.PlayOneShot(intro_VO[0]);
        yield return new WaitForSeconds(intro_VO[1].length);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void InitializeDefaultData()
    {
        // Disable all models
        //patient.SetActive(false);

        for (int i = 0; i < Guides.Count; i++)
        {
            Guides[i].SetActive(false);
        }

        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        Alcohol_Pads.GetComponent<BoxCollider>().enabled = false;
        Blood_Bag.GetComponent<BoxCollider>().enabled = false;
        BloodBag_IVPole.GetComponent<BoxCollider>().enabled = false;
        Normal_Saline.GetComponent<BoxCollider>().enabled = false;
        NormalSaline_IVPole.GetComponent<BoxCollider>().enabled = false;
        Roller_Clamp.GetComponent<BoxCollider>().enabled = false;
        Syringe.GetComponent<BoxCollider>().enabled = false;
        Volumetric_Pump.GetComponent<BoxCollider>().enabled = false;

        // 2) Disable all Gravity since Box Colliders are off
        Alcohol_Pads.GetComponent<Rigidbody>().useGravity = false;
        Blood_Bag.GetComponent<Rigidbody>().useGravity = false;
        BloodBag_IVPole.GetComponent<Rigidbody>().useGravity = false;
        Normal_Saline.GetComponent<Rigidbody>().useGravity = false;
        NormalSaline_IVPole.GetComponent<Rigidbody>().useGravity = false;
        Roller_Clamp.GetComponent<Rigidbody>().useGravity = false;
        Syringe.GetComponent<Rigidbody>().useGravity = false;
        Volumetric_Pump.GetComponent<Rigidbody>().useGravity = false;

    }
}
