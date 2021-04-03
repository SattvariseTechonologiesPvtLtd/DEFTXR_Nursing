using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Flow: InitializeDefaultData -> Introduction -> Update(GrabCheck) -> Step1 -> WoundAntiseptic1 -> Step2 -> 
// -> DustbinSwab -> Step3 -> Update(GrabCheck) -> TrayReplace -> Step4 -> Update(GrabCheck) -> Step5 ->
// -> SutureTweezer -> Step6 -> ScissorCut -> Step7 -> Update(GrabCheck) -> Step8 -> SutureTweezer1 ->
// -> Step9 -> ScissorCut1 -> Step10 -> Update(GrabCheck) -> Step10_2 -> WoundAntiseptic2 -> Step11 ->  DustbinSwab1 -> Step11_2 -> Update(GrabCheck) -> 
// -> Step12 -> SteriWound1 -> Step13 -> Update(GrabCheck) -> Step13_1 -> SteriWound2 -> Step13_2 -> Update(GrabCheck) -> Step14 ->
// -> SutureTweezer2 -> Step15 -> ScissorCut2 -> Step16 -> Update(GrabCheck) -> Step17 -> SutureTweezer3 -> Step18 -> ScissorCut3 -> Step19 ->
// -> Update(GrabCheck) -> Step20 -> SutureTweezer4 -> Step21 -> ScissorCut4 -> Step22 -> Update(GrabCheck) -> Step22_2 ->
// -> WoundAntiseptic3 -> Step23 -> DustbinSwab2 -> Step24 -> Update(GrabCheck) -> Step25 -> SteriWound3 -> Step26 ->
// -> Update(GrabCheck) -> Step27 -> SteriWound4 -> Step28 -> Update(GrabCheck) -> Step 29 -> SteriWound5 -> Step30

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

    private bool swab2Check = false;
    private bool strip2Check = false;

    //Wound Highlight Arrows
    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;
    public GameObject Arrow4;
    public GameObject Arrow5;


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
        Arrow1.SetActive(true);
        Arrow2.SetActive(true);
        Arrow3.SetActive(true);
        Arrow4.SetActive(true);
        Arrow5.SetActive(true);
        audioSource.PlayOneShot(intro_VO[5]);
        yield return new WaitForSeconds(intro_VO[5].length);
        yield return new WaitForSeconds(4f);
        //Highlight Wound OFF
        Arrow1.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);
        Arrow4.SetActive(false);
        Arrow5.SetActive(false);

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

        if (/*swab2.isGrabbed == true &&*/ ActionsCompleted[3] == true && swab2Check == false)
        {
            StartCoroutine(Step10_2());
        }

        if (/*steristrip1.isGrabbed == true &&*/ swab2Check == true && ActionsCompleted[4] == false)
        {
            StartCoroutine(Step12());
        }

        if (/*steristrip2.isGrabbed == true && */ ActionsCompleted[4] == true && strip2Check == false)
        {
            StartCoroutine(Step13_1());
        }

        if (/*tweezers.isGrabbed == true && scissor.isGrabbed == true &&*/ strip2Check == true && ActionsCompleted[5] == false)
        {
            StartCoroutine(Step14());
        }

        if (/*tweezers.isGrabbed == true && scissor.isGrabbed == true &&*/ ActionsCompleted[5] == true && ActionsCompleted[6] == false)
        {
            StartCoroutine(Step17());
        }

        if (/*tweezers.isGrabbed == true && scissor.isGrabbed == true &&*/ ActionsCompleted[6] == true && ActionsCompleted[7] == false)
        {
            StartCoroutine(Step20());
        }

        if (/*swab3.isGrabbed == true  &&*/ ActionsCompleted[7] == true && ActionsCompleted[8] == false)
        {
            StartCoroutine(Step22_2());
        }

        if (/*strip3.isGrabbed == true && */ ActionsCompleted[8] == true && ActionsCompleted[9] == false)
        {
            StartCoroutine(Step25());
        }

        if (/*strip4.isGrabbed == true && */ ActionsCompleted[9] == true && ActionsCompleted[10] == false)
        {
            StartCoroutine(Step27());
        }

        if (/*strip5.isGrabbed == true && */ ActionsCompleted[10] == true && ActionsCompleted[11] == false)
        {
            StartCoroutine(Step29());
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
        //Highlight All Suture Wound
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
        Arrow2.SetActive(true);
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
        Arrow2.SetActive(false);

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
        //Play Pull Guide
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
        Arrow4.SetActive(true);

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
        Arrow4.SetActive(false);

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

        //Play Pull Guide
        //Tweezer1_H SetActive(false)
        //Play Tweezer Pull Animation

        //Play Suture Drop in Tray Animation
        //Show Suture in Tray

        ActionsCompleted[3] = true;

    }

    public IEnumerator Step10_2()
    { 
        audioSource.PlayOneShot(intro_VO[22]);
        yield return new WaitForSeconds(intro_VO[22].length);
        yield return new WaitForSeconds(3f);

        antisepticSwabs2_H.SetActive(true);
        antisepticSwabs2.GetComponent<BoxCollider>().enabled = true;
        antisepticSwabs2.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step11()
    {
        swab2Check = true;
        //Play Antiseptic Apply Animation
        audioSource.PlayOneShot(intro_VO[23]);
        yield return new WaitForSeconds(intro_VO[23].length);
        yield return new WaitForSeconds(3f);

        dustbin_H.SetActive(true);
        dustbin.GetComponent<BoxCollider>().enabled = true;
    }

    public IEnumerator Step11_2()
    {
        audioSource.PlayOneShot(intro_VO[24]);
        yield return new WaitForSeconds(intro_VO[24].length);
        yield return new WaitForSeconds(3f);
        //Apply Steri Strips
        steriStrip1_H.SetActive(true);
        steriStrip1.GetComponent<BoxCollider>().enabled = true;
        steriStrip1.GetComponent<Rigidbody>().useGravity = true;

    }

    public IEnumerator Step12()
    {
        //Steri Strip Guide Set Active
        ActionsCompleted[4] = true;
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step13()
    {
        //Play Steri Strip 1 Apply Animation
        yield return new WaitForSeconds(3f);
        steriStrip1.GetComponent<BoxCollider>().enabled = false;
        steriStrip1.GetComponent<Rigidbody>().useGravity = false;

        steriStrip2_H.SetActive(true);
        steriStrip2.GetComponent<BoxCollider>().enabled = true;
        steriStrip2.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step13_1()
    {
        //Show Steri Strip Guide
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step13_2()
    {
        //Play Steri Strip 2 Apply Animation
        yield return new WaitForSeconds(3f);
        steriStrip2.GetComponent<BoxCollider>().enabled = false;
        steriStrip2.GetComponent<Rigidbody>().useGravity = false;

        strip2Check = true;

        audioSource.PlayOneShot(intro_VO[25]);
        yield return new WaitForSeconds(intro_VO[25].length);
        yield return new WaitForSeconds(3f);

        tweezers_H.SetActive(true);
        tweezers.GetComponent<BoxCollider>().enabled = true;
        tweezers.GetComponent<Rigidbody>().useGravity = true;
        scissors_H.SetActive(true);
        scissors.GetComponent<BoxCollider>().enabled = true;
        scissors.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step14()
    {
        audioSource.PlayOneShot(intro_VO[26]);
        yield return new WaitForSeconds(intro_VO[26].length);
        yield return new WaitForSeconds(3f);
        //Highlight 1st Suture
        Arrow1.SetActive(true);
        //BoxCollider On
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step15()
    {
        tweezers_H.SetActive(false);
        tweezers.GetComponent<BoxCollider>().enabled = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;
        Arrow1.SetActive(false);
        //Play Grab and Pull Suture Animation
        //SetActive CutGuide
        yield return new WaitForSeconds(3f);
        ActionsCompleted[5] = true;
    }

    public IEnumerator Step16()
    {
        scissors_H.SetActive(false);
        scissors.GetComponent<BoxCollider>().enabled = false;
        scissors.GetComponent<Rigidbody>().useGravity = false;
        //DeActive CutGuide
        //Play Cut Animation
        yield return new WaitForSeconds(3f);

        //Play Pull Guide
        //Tweezer1_H SetActive(false)
        //Play Tweezer Pull Animation

        //Play Suture Drop in Tray Animation
        //Show Suture in Tray

        audioSource.PlayOneShot(intro_VO[27]);
        yield return new WaitForSeconds(intro_VO[27].length);
        yield return new WaitForSeconds(3f);

        ScissorTweezerPos();
        tweezers_H.SetActive(true);
        tweezers.GetComponent<BoxCollider>().enabled = true;
        tweezers.GetComponent<Rigidbody>().useGravity = true;
        scissors_H.SetActive(true);
        scissors.GetComponent<BoxCollider>().enabled = true;
        scissors.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step17()
    {
        //Highlight 3rd Suture
        Arrow3.SetActive(true);
        //BoxCollider On
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step18()
    {
        tweezers_H.SetActive(false);
        tweezers.GetComponent<BoxCollider>().enabled = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;
        Arrow3.SetActive(false);
        //Play Grab and Pull Suture Animation
        //SetActive CutGuide
        yield return new WaitForSeconds(3f);
        ActionsCompleted[6] = true;
    }

    public IEnumerator Step19()
    {
        scissors_H.SetActive(false);
        scissors.GetComponent<BoxCollider>().enabled = false;
        scissors.GetComponent<Rigidbody>().useGravity = false;
        //DeActive CutGuide
        //Play Cut Animation
        yield return new WaitForSeconds(3f);

        //Play Pull Guide
        //Tweezer1_H SetActive(false)
        //Play Tweezer Pull Animation

        //Play Suture Drop in Tray Animation
        //Show Suture in Tray

        ScissorTweezerPos();
        tweezers_H.SetActive(true);
        tweezers.GetComponent<BoxCollider>().enabled = true;
        tweezers.GetComponent<Rigidbody>().useGravity = true;
        scissors_H.SetActive(true);
        scissors.GetComponent<BoxCollider>().enabled = true;
        scissors.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step20()
    {
        //Highlight 5th Suture
        Arrow5.SetActive(true);
        //BoxCollider On
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step21()
    {
        tweezers_H.SetActive(false);
        tweezers.GetComponent<BoxCollider>().enabled = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;
        Arrow5.SetActive(false);
        //Play Grab and Pull Suture Animation
        //SetActive CutGuide
        yield return new WaitForSeconds(3f);
        ActionsCompleted[7] = true;
    }

    public IEnumerator Step22()
    {
        scissors_H.SetActive(false);
        scissors.GetComponent<BoxCollider>().enabled = false;
        scissors.GetComponent<Rigidbody>().useGravity = false;
        //DeActive CutGuide
        //Play Cut Animation
        yield return new WaitForSeconds(3f);

        //Play Pull Guide
        //Tweezer1_H SetActive(false)
        //Play Tweezer Pull Animation

        //Play Suture Drop in Tray Animation
        //Show Suture in Tray

        ScissorTweezerPos();

        audioSource.PlayOneShot(intro_VO[28]);
        yield return new WaitForSeconds(intro_VO[28].length);
        yield return new WaitForSeconds(3f);

        antisepticSwabs3_H.SetActive(true);
        antisepticSwabs3.GetComponent<BoxCollider>().enabled = true;
        antisepticSwabs3.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step22_2()
    {
        //Highlight Wounded Area
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step23()
    {
        //Play Antiseptic Apply Animation

        ActionsCompleted[8] = true;
        dustbin_H.SetActive(true);
        dustbin.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step24()
    {
        steriStrip3_H.SetActive(true);
        steriStrip3.GetComponent<BoxCollider>().enabled = true;
        steriStrip3.GetComponent<Rigidbody>().useGravity = true;

        audioSource.PlayOneShot(intro_VO[29]);
        yield return new WaitForSeconds(intro_VO[29].length);
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(3f);
    }
    
    public IEnumerator Step25()
    {
        //Highlight Steri Guide 3
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step26()
    {
        ActionsCompleted[9] = true;
        //Play Steri Strip 3 Apply Animation
        yield return new WaitForSeconds(3f);
        steriStrip3.GetComponent<BoxCollider>().enabled = false;
        steriStrip3.GetComponent<Rigidbody>().useGravity = false;

        steriStrip4_H.SetActive(true);
        steriStrip4.GetComponent<BoxCollider>().enabled = true;
        steriStrip4.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step27()
    {
        //Highlight Steri Guide 4
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step28()
    {
        ActionsCompleted[10] = true;
        //Play Steri Strip 4 Apply Animation
        yield return new WaitForSeconds(3f);
        steriStrip4.GetComponent<BoxCollider>().enabled = false;
        steriStrip4.GetComponent<Rigidbody>().useGravity = false;

        steriStrip5_H.SetActive(true);
        steriStrip5.GetComponent<BoxCollider>().enabled = true;
        steriStrip5.GetComponent<Rigidbody>().useGravity = true;
    }

    public IEnumerator Step29()
    {
        //Highlight Steri Guide 4
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step30()
    {
        ActionsCompleted[11] = true;
        //Play Steri Strip 5 Apply Animation
        yield return new WaitForSeconds(3f);
        steriStrip5.GetComponent<BoxCollider>().enabled = false;
        steriStrip5.GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(3f);

        audioSource.PlayOneShot(intro_VO[30]);
        yield return new WaitForSeconds(intro_VO[30].length);
        yield return new WaitForSeconds(3f);
    }

    public IEnumerator Step31()
    {
        yield return new WaitForSeconds(3f);
    }

    
}

