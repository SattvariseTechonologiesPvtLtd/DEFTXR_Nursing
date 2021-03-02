using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BT_GameManager : MonoBehaviour
{
    public static BT_GameManager Instance;

    public Text debugText;

    public void Awake()
    {
        Instance = this;
    }

    // Audio Source and VO's
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> intro_VO;

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField]
    private List<GameObject> Guides;

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

        highlightObj.Instance.CannulaIV_Static_Highlighted.SetActive(true);
        //originalObj.Instance.CannulaIV_Static.SetActive(true);

        //Enable Cannula IV Grab
        originalObj.Instance.CannulaIV_Static.GetComponent<BoxCollider>().enabled = true;
        originalObj.Instance.CannulaIV_Static.GetComponent<Rigidbody>().useGravity = true;

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CannulaIV_Static")
        {
            originalObj.Instance.CannulaIV_Final.SetActive(true);
            highlightObj.Instance.CannulaIV_Final_Highlighted.SetActive(false);
            originalObj.Instance.CannulaIV_Static.SetActive(false);
            StartCoroutine(Step2());
        }
    }

    public void cannulaGrab()
    {
        equipmentLabels.Instance.CannulaIV_Name.SetActive(false);
        Guides[2].SetActive(false);
        StartCoroutine(Step1());
    }

    public void salineFlashGrab()
    {
        equipmentLabels.Instance.NormalSaline_Name.SetActive(false);
        Guides[3].SetActive(false);
        StartCoroutine(Step3());

    }

    /*public void ivTubeGrab1()
    {
        equipmentLabels.Instance.IVTube_Name.SetActive(false);
        Guides[5].SetActive(false);
        StartCoroutine(Step5());
    }*/


    private void Update()
    {
        if (originalObj.Instance.CannulaIV_Static.GetComponent<OVRGrabbable>().isGrabbed == true && isCannulaGrabCalled == false)
        {
            cannulaGrab();
            isCannulaGrabCalled = true;
         
        }

        if (originalObj.Instance.Normal_Saline.GetComponent<OVRGrabbable>().isGrabbed == true && isSalineFlashGrabCalled == false)
        {
            salineFlashGrab();
            isSalineFlashGrabCalled = true;
        }

       /* if (originalObj.Instance.SalineTube_Static.GetComponent<OVRGrabbable>().isGrabbed == true && isIvTUbeGrabCalled == false)
        {
            ivTubeGrab1();
            isIvTUbeGrabCalled = true;
        }*/
    }

    void InitializeDefaultData()
    {

        originalObj.Instance.Alcohol_Pads.SetActive(true);
        originalObj.Instance.Blood_Bag.SetActive(true);
        originalObj.Instance.Normal_Saline.SetActive(true);
        originalObj.Instance.Syringe.SetActive(true);
        originalObj.Instance.CannulaIV_Static.SetActive(true);
        originalObj.Instance.SalineTube_Static.SetActive(true);

        equipmentLabels.Instance.BloodBag_Name.SetActive(true);
        equipmentLabels.Instance.NormalSaline_Name.SetActive(true);
        equipmentLabels.Instance.CannulaIV_Name.SetActive(true);
        equipmentLabels.Instance.IVTube_Name.SetActive(true);
        equipmentLabels.Instance.Syringe_Name.SetActive(true);
        equipmentLabels.Instance.alcoholPad_Name.SetActive(true);



        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        originalObj.Instance.Blood_Bag.GetComponent<BoxCollider>().enabled = false;
        originalObj.Instance.Normal_Saline.GetComponent<BoxCollider>().enabled = false;
        originalObj.Instance.CannulaIV_Static.GetComponent<BoxCollider>().enabled = false;
        originalObj.Instance.SalineTube_Static.GetComponent<BoxCollider>().enabled = false;


        // 2) Disable all Gravity since Box Colliders are off
        originalObj.Instance.Blood_Bag.GetComponent<Rigidbody>().useGravity = false;
        originalObj.Instance.Normal_Saline.GetComponent<Rigidbody>().useGravity = false;
        originalObj.Instance.CannulaIV_Static.GetComponent<Rigidbody>().useGravity = false;
        originalObj.Instance.SalineTube_Static.GetComponent<Rigidbody>().useGravity = false;

    }

    public IEnumerator Step1()
    {
        //highlight final cannula position
        audioSource.PlayOneShot(intro_VO[8]);
        highlightObj.Instance.CannulaIV_Final_Highlighted.SetActive(true);
        yield return new WaitForSeconds(intro_VO[8].length);
    }

    public IEnumerator Step2()
    {
        originalObj.Instance.CannulaIV_Final.SetActive(true);
        originalObj.Instance.CannulaIV_Static.SetActive(false);
        highlightObj.Instance.CannulaIV_Final_Highlighted.SetActive(false);

        //Enable normal Saline to Grab
        //originalObj.Instance.Normal_Saline.GetComponent<BoxCollider>().enabled = true;
        // originalObj.Instance.Normal_Saline.GetComponent<Rigidbody>().useGravity = true;
        //originalObj.Instance.Normal_Saline.GetComponent<Rigidbody>().isKinematic = true;

        //pickup the Normal Saline vo
        Guides[3].SetActive(true);
        audioSource.PlayOneShot(intro_VO[9]);
        highlightObj.Instance.Normal_Saline_Highlighted.SetActive(true);

        originalObj.Instance.Normal_Saline.GetComponent<BoxCollider>().enabled = true;
        originalObj.Instance.Normal_Saline.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(intro_VO[9].length);

    }

    public IEnumerator Step3()
    {
        //hang it on IV pole
        Guides[4].SetActive(true);
        highlightObj.Instance.NormalSaline_IVPole_Highlighted.SetActive(true);
        //NormalSaline_IVPole.SetActive(false);
        audioSource.PlayOneShot(intro_VO[10]);
        yield return new WaitForSeconds(intro_VO[10].length);
        Guides[4].SetActive(false);

    }

    /*public IEnumerator Step4()
    {
        Guides[5].SetActive(true);
        audioSource.PlayOneShot(intro_VO[11]);
        highlightObj.Instance.SalineTube_Static_Highlighted.SetActive(true);
        originalObj.Instance.SalineTube_Static.SetActive(true);
        yield return null;
        //yield return new WaitForSeconds(intro_VO[11].length);

        //Enable static Saline tube to Grab
        originalObj.Instance.SalineTube_Static.GetComponent<BoxCollider>().enabled = true;
        originalObj.Instance.SalineTube_Static.GetComponent<Rigidbody>().useGravity = true;
    }*/

   /* public IEnumerator Step5()
    {
        //Attach To The Normal Saline
        Guides[6].SetActive(true);
        audioSource.PlayOneShot(intro_VO[12]);
        highlightObj.Instance.FlushBag_SalineTube_Highlighted.SetActive(true);
        yield return new WaitForSeconds(intro_VO[12].length);
    }*/

    public void salineEnable()
    {
        originalObj.Instance.Normal_Saline.GetComponent<BoxCollider>().enabled = true;
        originalObj.Instance.Normal_Saline.GetComponent<Rigidbody>().useGravity = true;
        originalObj.Instance.Normal_Saline.GetComponent<Rigidbody>().isKinematic = true;
    }
}
