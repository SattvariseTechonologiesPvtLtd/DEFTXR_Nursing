using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OA_GameManager : MonoBehaviour
{
    public static OA_GameManager Inst;
    public void Awake()
    {
        Inst = this;
    }

    // list of the audioclips required
    [SerializeField]
    private List<AudioClip> intro_VO;

    // Actions referencing Actions to be completed by user
    [SerializeField]
    private bool[] ActionsCompleted = { false };

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField]
    private List<GameObject> Guides;

    [SerializeField]
    private AudioSource audioSource;



    private bool grabbedOnce1 = false;
    private bool grabbedOnce2 = false;
    private bool grabbedOnce3 = false;
    private bool grabbedOnce4 = false;


    [SerializeField]
    private GameObject OxygenCylinder;
    [SerializeField]
    private GameObject TranstrachealCatheter;
    [SerializeField]
    private GameObject VenturiMask;
    [SerializeField]
    private GameObject NasalCanula;
    [SerializeField]
    private GameObject OxygenHood;
    [SerializeField]
    private GameObject NonRebreatherMask;
    [SerializeField]
    private GameObject FaceTent;
    [SerializeField]
    private GameObject NonRebreathermask_HA;
    [SerializeField]
    private GameObject NonRebreathermaskHA;
    [SerializeField] 
    private GameObject NonRebreathermask_H;
    [SerializeField]
    private GameObject OxygenCylinder_H;
    [SerializeField]
    private GameObject TranstrachealCatheter_H;
    [SerializeField]
    private GameObject VenturiMask_H;
    [SerializeField]
    private GameObject NasalCanula_H;
    [SerializeField]
    private GameObject OxygenHood_H;


    // Start is called before the first frame update
    void Start()
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
        yield return new WaitForSeconds(2f);

        audioSource.PlayOneShot(intro_VO[1]);
        yield return new WaitForSeconds(intro_VO[1].length);
        yield return new WaitForSeconds(1f);

        Debug.Log("playing vo2");
        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);
        yield return new WaitForSeconds(4f);

        audioSource.PlayOneShot(intro_VO[3]);
        yield return new WaitForSeconds(intro_VO[3].length);
        yield return new WaitForSeconds(3f);

        //Show Apparatus
        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);
        yield return new WaitForSeconds(4f);


    }


    // Update is called once per frame
    void Update()
    {




    }


    void InitializeDefaultData()
    {
        // Disable all models
        //patient.SetActive(false);

        

        // 1) Disable all Box Colliders to avoid getting grabbed.
        OxygenCylinder.GetComponent<BoxCollider>().enabled = false;
        FaceTent.GetComponent<BoxCollider>().enabled = false;
        NonRebreatherMask.GetComponent<BoxCollider>().enabled = false;
        TranstrachealCatheter.GetComponent<BoxCollider>().enabled = false;
        NasalCanula.GetComponent<BoxCollider>().enabled = false;
        OxygenHood.GetComponent<BoxCollider>().enabled = false;

        OxygenCylinder.GetComponent<Rigidbody>().useGravity = false;
        NonRebreatherMask.GetComponent<Rigidbody>().useGravity = false;
        TranstrachealCatheter.GetComponent<Rigidbody>().useGravity = false;
        NasalCanula.GetComponent<Rigidbody>().useGravity = false;
        OxygenHood.GetComponent<Rigidbody>().useGravity = false;






    }
    IEnumerator Step1()
    {
        // STEP 1 Pick Nasogastric Tube

        yield return new WaitForSeconds(3f);

    }

}
