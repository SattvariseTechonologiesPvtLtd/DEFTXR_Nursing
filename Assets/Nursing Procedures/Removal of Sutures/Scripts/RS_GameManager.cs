using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RS_GameManager : MonoBehaviour
{
    public static RS_GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }
    // list of the audioclips required
    [SerializeField] private List<AudioClip> intro_VO;

    // Actions referencing Actions to be completed by user
    [SerializeField] private bool[] ActionsCompleted = { false };

    // Guides referencing Guide Animation to be displayed on each step
    [SerializeField] private List<GameObject> Guides;

    [SerializeField] private AudioSource audioSource;


    private bool grabbedOnce1 = false;
    private bool grabbedOnce2 = false;
    private bool grabbedOnce3 = false;
    private bool grabbedOnce4 = false;

    //Equipments
    [SerializeField] private GameObject scissors;
    [SerializeField] private GameObject tweezers;
    [SerializeField] private GameObject antisepticSwabs;
    [SerializeField] private GameObject tray;
    [SerializeField] private GameObject tray1;
    [SerializeField] private GameObject steriStrips;
    [SerializeField] private GameObject dustbin;

    //Highlighted equipments
    [SerializeField] private GameObject scissors_H;
    [SerializeField] private GameObject tweezers_H;
    [SerializeField] private GameObject antisepticSwabs_H;
    [SerializeField] private GameObject tray_H;
    [SerializeField] private GameObject tray1_H;
    [SerializeField] private GameObject steriStrips_H;
    [SerializeField] private GameObject dustbin_H;

    //Labels
    public GameObject scissors_Name;
    public GameObject steri_strips_Name;
    public GameObject antiseptic_swab_Name;
    public GameObject tray_Name;
    public GameObject tweezers_Name;
    public GameObject dustbin_Name;

    public Text debugText;
    //private Hand grabbedBy;

    // Start is called before the first frame update
    void Start()
    {
        InitializeDefaultData();
        StartCoroutine(Introduction());
    }

    IEnumerator Introduction()
    {
        // Wait
        yield return new WaitForSeconds(5f);

        // Introduction
        Debug.Log("Playing Intro");
        audioSource.PlayOneShot(intro_VO[1]);
        yield return new WaitForSeconds(intro_VO[1].length);
        yield return new WaitForSeconds(3f);

        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);
        yield return new WaitForSeconds(3f);


        //Show Equipments
        Debug.Log("Playing Equipment Intro");
        audioSource.PlayOneShot(intro_VO[3]);
        yield return new WaitForSeconds(intro_VO[3].length);
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);
        yield return new WaitForSeconds(4f);


        //Step 1: Show patient wounds
        Debug.Log("Play Patient Wounds");
        //Highlight Patient Wounds here
        audioSource.PlayOneShot(intro_VO[5]);
        yield return new WaitForSeconds(intro_VO[5].length);
        yield return new WaitForSeconds(4f);
        //Highlight Wound OFF

        //Step 2. Grab the Antiseptic Swab
        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);
        Guides[0].SetActive(true);
        antisepticSwabs.SetActive(false);
        antisepticSwabs_H.SetActive(true);
        antisepticSwabs.GetComponent<Rigidbody>().useGravity = true;
        antisepticSwabs.GetComponent<BoxCollider>().enabled = true;

        /* Debug.Log("Play VO3");
         audioSource.PlayOneShot(intro_VO[6]);
         //   PlayGuide(1);                         
         //Playing Animation of procedure area getting cobered with curtains.
         yield return new WaitForSeconds(intro_VO[6].length);

         // Step 3 : Proper Body Mechanism
         Debug.Log("Play VO5");
         audioSource.PlayOneShot(intro_VO[10]);
         //    PlayGuide(2);    
         //Playing Animation of bed in semi-fold position and patient getting lie down on the back.
         yield return new WaitForSeconds(intro_VO[10].length);*/

    }

    // Update is called once per frame
    void Update()
    {
        /*debugText.text = "Inside update function";
        if (tray.GetComponent<GrabAttacher>().GrabbedBody != null )
        {
            debugText.text = "Inside if";
        }*/

        if (/*swab.isGrabbed == true &&*/ ActionsCompleted[0] == false)
        {
            StartCoroutine(Step1());
        }

        if(/*tray.isGrabbed == true &&*/ ActionsCompleted[0] == true && ActionsCompleted[1] == false)
        {
            tray1_H.SetActive(true);
        }
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
        scissors.GetComponent<BoxCollider>().enabled = false;
        tweezers.GetComponent<BoxCollider>().enabled = false;
        steriStrips.GetComponent<BoxCollider>().enabled = false;
        tray.GetComponent<BoxCollider>().enabled = false;
        antisepticSwabs.GetComponent<BoxCollider>().enabled = false;
        dustbin_H.GetComponent<BoxCollider>().enabled = false;


        // 2) Disable all Gravity since Box Colliders are off
        scissors.GetComponent<Rigidbody>().useGravity = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;
        steriStrips.GetComponent<Rigidbody>().useGravity = false;
        tray.GetComponent<Rigidbody>().useGravity = false;
        antisepticSwabs.GetComponent<Rigidbody>().useGravity = false;

    }

    public IEnumerator Step1()
    {
        audioSource.PlayOneShot(intro_VO[7]);
        yield return new WaitForSeconds(intro_VO[7].length);
        yield return new WaitForSeconds(5f);
        //Highlight Wound
    }

    public IEnumerator Step2()
    {
        //Discard the swab into Dustbin
        dustbin_H.SetActive(true);
        dustbin_H.GetComponent<BoxCollider>().enabled = true;
        audioSource.PlayOneShot(intro_VO[8]);
        yield return new WaitForSeconds(intro_VO[8].length);
        yield return new WaitForSeconds(5f);
        ActionsCompleted[0] = true;
    }

    public IEnumerator Step3()
    {
        //Swab Disappear after Collision
        antisepticSwabs.SetActive(false);
        antisepticSwabs.GetComponent<BoxCollider>().enabled = false;
        antisepticSwabs.GetComponent<Rigidbody>().useGravity = false;
        dustbin_H.SetActive(false);
        dustbin_H.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(5f);
        //Antiseptic on the wound dries 
        audioSource.PlayOneShot(intro_VO[9]);
        yield return new WaitForSeconds(intro_VO[9].length);
        yield return new WaitForSeconds(5f);

        tray_H.SetActive(true);
        tray.GetComponent<BoxCollider>().enabled = true;
        tray.GetComponent<Rigidbody>().useGravity = true;
        audioSource.PlayOneShot(intro_VO[10]);
        yield return new WaitForSeconds(intro_VO[10].length);
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step4()
    {
        tray.SetActive(false);
        //Tray Grab END
        tray1.SetActive(true);
        tray1_H.SetActive(false);
        audioSource.PlayOneShot(intro_VO[11]);
        yield return new WaitForSeconds(intro_VO[11].length);
    }
}

