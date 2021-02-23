using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_GameManager : MonoBehaviour
{
    // list of the audioclips required
    [SerializeField]
    private List<AudioClip> intro_VO;

    // Actions referencing Actions to be completed by user
    [SerializeField]
    private bool[] ActionsCompleted = { false };

    [SerializeField]
    private AudioSource audioSource;

    // Model of Patient lying on Bed
    [SerializeField]
    private GameObject patient;

    private bool grabbedOnce1 = false;
    private bool grabbedOnce2 = false;
    private bool grabbedOnce3 = false;
    private bool grabbedOnce4 = false;

    // Grababble Apparatus
    [SerializeField]
    private GameObject Alcohol_Pads;
    [SerializeField]
    private GameObject Blood_Bag;
    [SerializeField]
    private GameObject Normal_Saline;
    [SerializeField]
    private GameObject Syringe;
    [SerializeField]
    private GameObject Infusion_Pumps;
    [SerializeField]
    private GameObject BloodBag_IVPole;
    [SerializeField]
    private GameObject NormalSaline_IVPole;
    [SerializeField]
    private GameObject CannulaIV_Final;
    [SerializeField]
    private GameObject CannulaIV_Static;
    [SerializeField]
    private GameObject SalineTube_Static;
    [SerializeField]
    private GameObject BloodBag_SalineTube;
    [SerializeField]
    private GameObject FlushBag_SalineTube;

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField]
    private List<GameObject> Guides;

    //List of Highlighted Equipments
    [SerializeField]
    private GameObject Alcohol_Pads_Highlighted;
    [SerializeField]
    private GameObject Blood_Bag_Highlighted;
    [SerializeField]
    private GameObject Normal_Saline_Highlighted;
    [SerializeField]
    private GameObject Syringe_Highlighted;
    [SerializeField]
    private GameObject Infusion_Pumps_Highlighted;
    [SerializeField]
    private GameObject BloodBag_IVPole_Highlighted;
    [SerializeField]
    private GameObject NormalSaline_IVPole_Highlighted;
    [SerializeField]
    private GameObject CannulaIV_Final_Highlighted;
    [SerializeField]
    private GameObject CannulaIV_Static_Highlighted;
    [SerializeField]
    private GameObject SalineTubeStatic_Static_Highlighted;
    [SerializeField]
    private GameObject BloodBag_SalineTube_Highlighted;
    [SerializeField]
    private GameObject FlushBag_SalineTube_Highlighted;

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField]
    private List<GameObject> Labels;

    //Labels
    public GameObject BloodBag_Name;
    public GameObject NormalSaline_Name;
    public GameObject CannulaIV_Name;
    public GameObject IVTube_Name;

    public GameObject Arrow_animation;


    private void Start()
    {

        InitializeDefaultData();

        StartCoroutine(Introduction());
    }


    IEnumerator Introduction()
    {
        // Introduction
        Debug.Log("playing vo1");
        audioSource.PlayOneShot(intro_VO[0]);
        yield return new WaitForSeconds(intro_VO[0].length);

        audioSource.PlayOneShot(intro_VO[1]);
        yield return new WaitForSeconds(intro_VO[1].length);

        Debug.Log("playing vo2");
        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);
        yield return new WaitForSeconds(4f);

        audioSource.PlayOneShot(intro_VO[3]);
        yield return new WaitForSeconds(intro_VO[3].length);
        yield return new WaitForSeconds(3f);

        //Wash Hands 
        Guides[0].SetActive(true);
        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);
        Guides[0].SetActive(false);
        yield return new WaitForSeconds(3f);

        //Show Apparatus
        Arrow_animation.SetActive(true);
        Arrow_animation.GetComponent<Animator>().Play("ArrowAnimation");
        audioSource.PlayOneShot(intro_VO[5]);
        yield return new WaitForSeconds(intro_VO[5].length);

        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);
        yield return new WaitForSeconds(2f);

        audioSource.PlayOneShot(intro_VO[7]);
        yield return new WaitForSeconds(intro_VO[7].length);

        Arrow_animation.SetActive(false);

        //Make Patient Position
        audioSource.PlayOneShot(intro_VO[8]);
        yield return new WaitForSeconds(intro_VO[8].length);
        yield return new WaitForSeconds(5f);

        //Wear Gloves
        audioSource.PlayOneShot(intro_VO[9]);
        yield return new WaitForSeconds(intro_VO[9].length);
        yield return new WaitForSeconds(3f);

        //Pick Up The Cannula IV
        audioSource.PlayOneShot(intro_VO[10]);
        CannulaIV_Static.SetActive(false);
        CannulaIV_Final.SetActive(false);
        CannulaIV_Static_Highlighted.SetActive(true);
        CannulaIV_Final_Highlighted.SetActive(true);
        //Enable Cannula_IV
        CannulaIV_Static.GetComponent<BoxCollider>().enabled = true;
        CannulaIV_Static.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(intro_VO[10].length);
        yield return new WaitForSeconds(2f);

        Normal_Saline.GetComponent<BoxCollider>().enabled = true;
        Normal_Saline.GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
       if (CannulaIV_Static.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {

            StartCoroutine(Step1());
            ActionsCompleted[1] = true;

            Normal_Saline.SetActive(false);
            NormalSaline_IVPole.SetActive(false);
            Normal_Saline_Highlighted.SetActive(true);
            NormalSaline_IVPole_Highlighted.SetActive(true);

            Normal_Saline.GetComponent<BoxCollider>().enabled = true;
            Normal_Saline.GetComponent<Rigidbody>().useGravity = true;

        }

       if (Normal_Saline.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step2());
            ActionsCompleted[2] = true;

            SalineTube_Static.SetActive(false);
            FlushBag_SalineTube.SetActive(false);
            SalineTubeStatic_Static_Highlighted.SetActive(true);
            FlushBag_SalineTube_Highlighted.SetActive(true);

            SalineTube_Static.GetComponent<BoxCollider>().enabled = true;
            SalineTube_Static.GetComponent<Rigidbody>().useGravity = true;

            Blood_Bag.GetComponent<BoxCollider>().enabled = true;
            Blood_Bag.GetComponent<Rigidbody>().useGravity = true;

        }

        if (Blood_Bag.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
            StartCoroutine(Step3());
            ActionsCompleted[3] = true;

            Blood_Bag.SetActive(false);
            BloodBag_SalineTube.SetActive(false);
            Blood_Bag_Highlighted.SetActive(true);
            BloodBag_SalineTube_Highlighted.SetActive(true);

            SalineTube_Static.GetComponent<BoxCollider>().enabled = true;
            SalineTube_Static.GetComponent<Rigidbody>().useGravity = true;
        }

        if (SalineTube_Static.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false)
        {
            StartCoroutine(Step4());
            ActionsCompleted[4] = true;

            SalineTube_Static.SetActive(false);
            BloodBag_SalineTube.SetActive(false);
            SalineTubeStatic_Static_Highlighted.SetActive(true);
            BloodBag_SalineTube_Highlighted.SetActive(true);
        }

    }

    void InitializeDefaultData()
    {

        Alcohol_Pads.SetActive(true);
        Blood_Bag.SetActive(true);
        Normal_Saline.SetActive(true);
        Syringe.SetActive(true);
        Infusion_Pumps.SetActive(true);
        CannulaIV_Static.SetActive(true);
        SalineTube_Static.SetActive(true);


        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        Blood_Bag.GetComponent<BoxCollider>().enabled = false;
        Normal_Saline.GetComponent<BoxCollider>().enabled = false;
        CannulaIV_Static.GetComponent<BoxCollider>().enabled = false;
        SalineTube_Static.GetComponent<BoxCollider>().enabled = false;


        // 2) Disable all Gravity since Box Colliders are off
        Blood_Bag.GetComponent<Rigidbody>().useGravity = false;
        Normal_Saline.GetComponent<Rigidbody>().useGravity = false;
        CannulaIV_Static.GetComponent<Rigidbody>().useGravity = false;
        SalineTube_Static.GetComponent<Rigidbody>().useGravity = false;

    }



    IEnumerator Step1()
    {
        // STEP 1 Pick Nasogastric Tube

       audioSource.PlayOneShot(intro_VO[11]);
       
       yield return new WaitForSeconds(intro_VO[11].length);

    }

    IEnumerator Step2()
    {
        // step 2 Highlight Tape and Attach to Nasogastric Tube
        Guides[5].SetActive(true);
        audioSource.PlayOneShot(intro_VO[11]);
        yield return new WaitForSeconds(intro_VO[11].length);
    }

    IEnumerator Step3()
    {
        // Step 3 Highlight Water Soluble Lubricant
        // Lubricate about 2 – 4 inches of the tube with a lubricant
        Guides[6].SetActive(true);
        audioSource.PlayOneShot(intro_VO[12]);
        yield return new WaitForSeconds(intro_VO[12].length);
        Guides[6].SetActive(false);
        yield return new WaitForSeconds(4f);

        // play insert tube animation

        Guides[7].SetActive(true);
        audioSource.PlayOneShot(intro_VO[13]);
 
        yield return new WaitForSeconds(intro_VO[13].length);
        Guides[7].SetActive(false);
    
        yield return new WaitForSeconds(4f);

        Guides[8].SetActive(true);
        audioSource.PlayOneShot(intro_VO[14]);
        yield return new WaitForSeconds(intro_VO[14].length);
        Guides[8].SetActive(false);
        yield return new WaitForSeconds(2f);

        Guides[15].SetActive(true);
        yield return new WaitForSeconds(2f);

    }

    IEnumerator Step4()
    {

        Guides[9].SetActive(true);
        audioSource.PlayOneShot(intro_VO[15]);
        yield return new WaitForSeconds(intro_VO[15].length);

        Guides[9].SetActive(false);
        yield return new WaitForSeconds(3f);

        Guides[14].SetActive(true);
       
        yield return new WaitForSeconds(3f);
        Guides[14].SetActive(false);

        Guides[10].SetActive(true);
        audioSource.PlayOneShot(intro_VO[16]);
        yield return new WaitForSeconds(intro_VO[16].length);
        Guides[10].SetActive(false);

    }
}
