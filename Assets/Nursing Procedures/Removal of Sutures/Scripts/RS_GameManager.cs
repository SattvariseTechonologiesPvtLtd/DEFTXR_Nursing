using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Flow: InitializeDefaultData -> Introduction -> Update(GrabCheck) -> Step1 -> WoundAntiseptic1 -> Step2 -> 
// -> DustbinSwab -> Step3 -> Update(GrabCheck) -> TrayReplace -> Step4 -> Update(GrabCheck) -> Step5 ->
// -> SutureTweezer -> Step6 -> SutureCut -> Step7 -> Update(GrabCheck) -> Step8 -> SutureTweezer

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
    [SerializeField] private GameObject antisepticSwabs1;
    [SerializeField] private GameObject antisepticSwabs2;
    [SerializeField] private GameObject antisepticSwabs3;
    [SerializeField] private GameObject tray;
    [SerializeField] private GameObject tray1;
    [SerializeField] private GameObject steriStrip1;
    [SerializeField] private GameObject steriStrip2;
    [SerializeField] private GameObject steriStrip3;
    [SerializeField] private GameObject steriStrip4;
    [SerializeField] private GameObject steriStrip5;
    [SerializeField] private GameObject dustbin;

    //Highlighted equipments
    [SerializeField] private GameObject scissors_H;
    [SerializeField] private GameObject tweezers_H;
    [SerializeField] private GameObject antisepticSwabs1_H;
    [SerializeField] private GameObject antisepticSwabs2_H;
    [SerializeField] private GameObject antisepticSwabs3_H;
    [SerializeField] private GameObject tray_H;
    [SerializeField] private GameObject tray1_H;
    [SerializeField] private GameObject steriStrip1_H;
    [SerializeField] private GameObject steriStrip2_H;
    [SerializeField] private GameObject steriStrip3_H;
    [SerializeField] private GameObject steriStrip4_H;
    [SerializeField] private GameObject steriStrip5_H;
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

    //Original Positions and Rotation
    private Vector3 scissorPos;
    private Vector3 tweezersPos;
    private Quaternion scissorRotate;
    private Quaternion tweezerRotate;

    

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
        antisepticSwabs1.SetActive(false);
        antisepticSwabs1_H.SetActive(true);
        antisepticSwabs1.GetComponent<Rigidbody>().useGravity = true;
        antisepticSwabs1.GetComponent<BoxCollider>().enabled = true;

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

        if (/*swab1.isGrabbed == true &&*/ ActionsCompleted[0] == false)
        {
            StartCoroutine(Step1());
        }

        if (/*tray.isGrabbed == true &&*/ ActionsCompleted[0] == true && ActionsCompleted[1] == false)
        {
            tray1_H.SetActive(true);
        }

        if (/*tweezers.isGrabbed == true && scissor.isGrabbed == true &&*/ ActionsCompleted[1] == true && ActionsCompleted[2] == false)
        {
            StartCoroutine(Step5());
        }

        if (/*tweezers.isGrabbed == true && scissor.isGrabbed == true &&*/ ActionsCompleted[2] == true && ActionsCompleted[3] == false)
        {
            StartCoroutine(Step8());
        }

        if(/*steristrip.isGrabbed == true &&*/ ActionsCompleted[3] == true && ActionsCompleted[4] == false)
        {
            StartCoroutine(Step12());
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
        steriStrip1.GetComponent<BoxCollider>().enabled = false;
        steriStrip2.GetComponent<BoxCollider>().enabled = false;
        steriStrip3.GetComponent<BoxCollider>().enabled = false;
        steriStrip4.GetComponent<BoxCollider>().enabled = false;
        steriStrip5.GetComponent<BoxCollider>().enabled = false;
        tray.GetComponent<BoxCollider>().enabled = false;
        antisepticSwabs1.GetComponent<BoxCollider>().enabled = false;
        antisepticSwabs2.GetComponent<BoxCollider>().enabled = false;
        antisepticSwabs3.GetComponent<BoxCollider>().enabled = false;
        dustbin_H.GetComponent<BoxCollider>().enabled = false;


        // 2) Disable all Gravity since Box Colliders are off
        scissors.GetComponent<Rigidbody>().useGravity = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;
        steriStrip1.GetComponent<Rigidbody>().useGravity = false;
        steriStrip2.GetComponent<Rigidbody>().useGravity = false;
        steriStrip3.GetComponent<Rigidbody>().useGravity = false;
        steriStrip4.GetComponent<Rigidbody>().useGravity = false;
        steriStrip5.GetComponent<Rigidbody>().useGravity = false;
        tray.GetComponent<Rigidbody>().useGravity = false;
        antisepticSwabs1.GetComponent<Rigidbody>().useGravity = false;
        antisepticSwabs2.GetComponent<Rigidbody>().useGravity = false;
        antisepticSwabs3.GetComponent<Rigidbody>().useGravity = false;

        //Original Pos and Rotate
        scissorPos = scissors.gameObject.transform.position;
        tweezersPos = tweezers.gameObject.transform.position;
        scissorRotate = scissors.gameObject.transform.rotation;
        tweezerRotate = tweezers.gameObject.transform.rotation;
    }

    public void ScissorTweezerPos()
    {
        // Scissor and tweezer back to original position
        scissors.gameObject.transform.position = scissorPos;
        tweezers.gameObject.transform.position = tweezersPos;

        //original Rotation
        scissors.gameObject.transform.rotation = scissorRotate;
        tweezers.gameObject.transform.rotation = tweezerRotate;
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
        //Discard the swab1 into Dustbin
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
        antisepticSwabs1.SetActive(false);
        antisepticSwabs1.GetComponent<BoxCollider>().enabled = false;
        antisepticSwabs1.GetComponent<Rigidbody>().useGravity = false;
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
        //Tray Replace 
        ActionsCompleted[1] = true;
        tray.SetActive(false);
        tray.GetComponent<BoxCollider>().enabled = false;
        tray.GetComponent<Rigidbody>().useGravity = false;
        //Tray Grab END
        tray1.SetActive(true);
        tray1_H.SetActive(false);
        audioSource.PlayOneShot(intro_VO[11]);
        yield return new WaitForSeconds(intro_VO[11].length);
        yield return new WaitForSeconds(3f);

        tweezers_H.SetActive(true);
        tweezers.GetComponent<BoxCollider>().enabled = true;
        tweezers.GetComponent<Rigidbody>().useGravity = true;
        scissors_H.SetActive(true);
        scissors.GetComponent<BoxCollider>().enabled = true;
        scissors.GetComponent<Rigidbody>().useGravity = true;
        audioSource.PlayOneShot(intro_VO[12]);
        yield return new WaitForSeconds(intro_VO[12].length);
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step5()
    {
        // Highlight 2nd Suture and turn on its Box Collider
        audioSource.PlayOneShot(intro_VO[13]);
        yield return new WaitForSeconds(intro_VO[13].length);
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step6()
    {
        //Tweezers Grab End
        tweezers_H.SetActive(false);
        tweezers.GetComponent<BoxCollider>().enabled = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;

        audioSource.PlayOneShot(intro_VO[14]);
        //Play Suture Grab and Pull Animation
        yield return new WaitForSeconds(intro_VO[14].length);
        yield return new WaitForSeconds(3f);
        //Tweezer1_H SetActive

        audioSource.PlayOneShot(intro_VO[15]);
        yield return new WaitForSeconds(intro_VO[15].length);
        yield return new WaitForSeconds(3f);
        //Cut Guide SetActive
    }

    public IEnumerator Step7()
    {
        //Scissors Grab End
        scissors_H.SetActive(false);
        scissors.GetComponent<BoxCollider>().enabled = false;
        scissors.GetComponent<Rigidbody>().useGravity = false;
        ScissorTweezerPos();
        //Cut Guide DeActive
        //Play Scissor cutting Suture Animation

        audioSource.PlayOneShot(intro_VO[16]);
        yield return new WaitForSeconds(intro_VO[16].length);
        yield return new WaitForSeconds(3f);
        //Play Arrow Guide
        //Tweezer1_H SetActive(false)
        //Play Tweezer Pull Animation

        audioSource.PlayOneShot(intro_VO[17]);
        yield return new WaitForSeconds(intro_VO[17].length);
        yield return new WaitForSeconds(3f);
        //Play Suture Drop in Tray Animation
        //Show Suture in Tray

        audioSource.PlayOneShot(intro_VO[18]);
        yield return new WaitForSeconds(intro_VO[18].length);
        yield return new WaitForSeconds(3f);

        ActionsCompleted[2] = true;

        audioSource.PlayOneShot(intro_VO[19]);
        yield return new WaitForSeconds(intro_VO[19].length);
        yield return new WaitForSeconds(3f);

        tweezers_H.SetActive(true);
        tweezers.GetComponent<BoxCollider>().enabled = true;
        tweezers.GetComponent<Rigidbody>().useGravity = true;
        scissors_H.SetActive(true);
        scissors.GetComponent<BoxCollider>().enabled = true;
        scissors.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step8()
    {
        //Highlight 4th Suture
        //BoxCollider On 4th Suture
        audioSource.PlayOneShot(intro_VO[20]);
        yield return new WaitForSeconds(intro_VO[20].length);
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step9()
    {
        //Tweezers Grab End
        tweezers_H.SetActive(false);
        tweezers.GetComponent<BoxCollider>().enabled = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;


        //Play Tweezer Grab and Pull Animation
        audioSource.PlayOneShot(intro_VO[21]);
        yield return new WaitForSeconds(intro_VO[21].length);
        yield return new WaitForSeconds(3f);

        //Cut Guide SetActive
    }

    public IEnumerator Step10()
    {
        //Scissors Grab End
        scissors_H.SetActive(false);
        scissors.GetComponent<BoxCollider>().enabled = false;
        scissors.GetComponent<Rigidbody>().useGravity = false;
        ScissorTweezerPos();
        //Cut Guide DeActive
        //Play Scissor cutting Suture Animation
        yield return new WaitForSeconds(3f);

        //Play Arrow Guide
        //Tweezer1_H SetActive(false)
        //Play Tweezer Pull Animation

        //Play Suture Drop in Tray Animation
        //Show Suture in Tray

        ActionsCompleted[3] = true;

        audioSource.PlayOneShot(intro_VO[22]);
        yield return new WaitForSeconds(intro_VO[22].length);
        yield return new WaitForSeconds(3f);

        antisepticSwabs2_H.SetActive(true);
        antisepticSwabs2.GetComponent<BoxCollider>().enabled = true;
        antisepticSwabs2.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step11()
    {
        //Play Antiseptic Apply Animation
        audioSource.PlayOneShot(intro_VO[23]);
        yield return new WaitForSeconds(intro_VO[23].length);
        yield return new WaitForSeconds(3f);

        audioSource.PlayOneShot(intro_VO[24]);
        yield return new WaitForSeconds(intro_VO[24].length);
        yield return new WaitForSeconds(3f);

        steriStrip1_H.SetActive(true);
        steriStrip1.GetComponent<BoxCollider>().enabled = true;
        steriStrip1.GetComponent<Rigidbody>().useGravity = true;

    }

    public IEnumerator Step12()
    {
        //Steri Strip Guide Set Active
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step13()
    {
        //Play Steri Strip Apply Animation
        steriStrip1.GetComponent<BoxCollider>().enabled = false;
        steriStrip1.GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(3f);
    }
}

