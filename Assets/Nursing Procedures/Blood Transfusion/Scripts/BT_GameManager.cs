using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BT_GameManager : MonoBehaviour
{
    public static BT_GameManager Instance, Inst;

    public Text debugText;

    private void Awake()
    {
        Instance = this;
        Inst = this;
    }

    // list of the audioclips required
    [SerializeField]
    private List<AudioClip> intro_VO;

    // Actions referencing Actions to be completed by user
    [SerializeField]
    public bool[] ActionsCompleted = { false };

    [SerializeField]
    private AudioSource audioSource;

    // Model of Patient lying on Bed
    [SerializeField]
    private GameObject patient;

    // Grababble Apparatus
    [SerializeField]
    private GameObject Alcohol_Pads;
    [SerializeField]
    private GameObject Blood_Bag;
    [SerializeField]
    public GameObject Normal_Saline;
    [SerializeField]
    private GameObject Syringe;
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
    private GameObject BloodBag_IVPole_Highlighted;
    [SerializeField]
    private GameObject NormalSaline_IVPole_Highlighted;
    [SerializeField]
    private GameObject CannulaIV_Final_Highlighted;
    [SerializeField]
    private GameObject CannulaIV_Static_Highlighted;
    [SerializeField]
    private GameObject SalineTube_Static_Highlighted;
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
    public GameObject Syringe_Name;
    public GameObject alcoholPad_Name;

    bool isCannulaGrabCalled = false;
    bool isSalineFlashGrabCalled = false;
    bool isIvTUbeGrabCalled = false;
    public GameObject Arrow_animation;

    private void Start()
    {

        InitializeDefaultData();

        StartCoroutine(Introduction());

        //cannulaGrab();

    }


    IEnumerator Introduction()
    {
        //wait
        //yield return new WaitForSeconds(10f);

        // Introduction
        /*audioSource.PlayOneShot(intro_VO[0]);
        yield return new WaitForSeconds(intro_VO[0].length);
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(intro_VO[1]);
        yield return new WaitForSeconds(intro_VO[1].length);
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);
        yield return new WaitForSeconds(4f);

        //Wash Hands
        Guides[0].SetActive(true);
        audioSource.PlayOneShot(intro_VO[3]);
        yield return new WaitForSeconds(intro_VO[3].length);
        Guides[0].SetActive(false);
        yield return new WaitForSeconds(4f);

        //Show Equipments
        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);
        yield return new WaitForSeconds(1f);

        audioSource.PlayOneShot(intro_VO[5]);
        Arrow_animation.SetActive(true);
        Arrow_animation.GetComponent<Animator>().Play("ArrowAnimation");
        yield return new WaitForSeconds(intro_VO[5].length);
        Arrow_animation.SetActive(false);
        yield return new WaitForSeconds(3f);*/

        //Instruction ( patient lie down )
        Guides[1].SetActive(true);
        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);
        Guides[1].SetActive(false);
        yield return new WaitForSeconds(4f);

        //Task 1 Pick Up The Cannula
        Guides[2].SetActive(true);
        audioSource.PlayOneShot(intro_VO[7]);
        yield return new WaitForSeconds(intro_VO[7].length);

        CannulaIV_Static_Highlighted.SetActive(true);
        CannulaIV_Static.SetActive(true);
        //Enable Cannula IV Grab
        CannulaIV_Static.GetComponent<BoxCollider>().enabled = true;
        CannulaIV_Static.GetComponent<Rigidbody>().useGravity = true;
        
    }

    public void cannulaGrab()
    {
        CannulaIV_Name.SetActive(false);
        Guides[2].SetActive(false);
        StartCoroutine(Step1());
    }

    public void salineFlashGrab()
    {
        NormalSaline_Name.SetActive(false);
        Guides[3].SetActive(false);
        StartCoroutine(Step3());

    }

    public void ivTubeGrab1()
    {
        IVTube_Name.SetActive(false);
        Guides[5].SetActive(false);
        StartCoroutine(Step5());
    }


    private void Update()
    {
        if (CannulaIV_Static.GetComponent<OVRGrabbable>().isGrabbed == true && isCannulaGrabCalled == false)
        {
            cannulaGrab();
            isCannulaGrabCalled = true;

        }

        if (Normal_Saline.GetComponent<OVRGrabbable>().isGrabbed == true && isSalineFlashGrabCalled == false)
        {
            salineFlashGrab();
            isSalineFlashGrabCalled = true;
        }

        if (SalineTube_Static.GetComponent<OVRGrabbable>().isGrabbed == true && isIvTUbeGrabCalled == false)
        {
            ivTubeGrab1();
            isIvTUbeGrabCalled = true;
        }
    }

    void InitializeDefaultData()
    {

        Alcohol_Pads.SetActive(true);
        Blood_Bag.SetActive(true);
        Normal_Saline.SetActive(true);
        Syringe.SetActive(true);
        CannulaIV_Static.SetActive(true);
        SalineTube_Static.SetActive(true);

        BloodBag_Name.SetActive(true);
        NormalSaline_Name.SetActive(true);
        CannulaIV_Name.SetActive(true);
        IVTube_Name.SetActive(true);
        Syringe_Name.SetActive(true);
        alcoholPad_Name.SetActive(true);



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

    public IEnumerator Step1()
    {
        //highlight final cannula position
        audioSource.PlayOneShot(intro_VO[8]);
        CannulaIV_Final_Highlighted.SetActive(true);
        yield return new WaitForSeconds(intro_VO[8].length);
    }

    public IEnumerator Step2()
    {
        //Enable normal Saline to Grab
        Normal_Saline.GetComponent<BoxCollider>().enabled = true;
        Normal_Saline.GetComponent<Rigidbody>().useGravity = true;
        //pickup the Normal Saline vo
        Guides[3].SetActive(true);
        audioSource.PlayOneShot(intro_VO[9]);
        Normal_Saline_Highlighted.SetActive(true);  
        Normal_Saline.SetActive(true);
        yield return new WaitForSeconds(intro_VO[9].length);
   
        //debugText.text = "i am in step 2" + " | val - " + Normal_Saline.GetComponent<BoxCollider>().enabled;
    }

    public IEnumerator Step3()
    {
        //hang it on IV pole
        Guides[4].SetActive(true);
        NormalSaline_IVPole_Highlighted.SetActive(true);
        //NormalSaline_IVPole.SetActive(false);
        audioSource.PlayOneShot(intro_VO[10]);
        yield return new WaitForSeconds(intro_VO[10].length);
        Guides[4].SetActive(false);

    }

    public IEnumerator Step4()
    {
        audioSource.PlayOneShot(intro_VO[11]);
        Guides[5].SetActive(true);
        SalineTube_Static_Highlighted.SetActive(true);
        SalineTube_Static.SetActive(true);
        yield return new WaitForSeconds(intro_VO[11].length);
        
        //Enable static Saline tube to Grab
        SalineTube_Static.GetComponent<BoxCollider>().enabled = true;
        SalineTube_Static.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step5()
    {
        //Attach To The Normal Saline
        Guides[6].SetActive(true);
        audioSource.PlayOneShot(intro_VO[12]);
        FlushBag_SalineTube_Highlighted.SetActive(true);
        yield return new WaitForSeconds(intro_VO[12].length);
    }
}
