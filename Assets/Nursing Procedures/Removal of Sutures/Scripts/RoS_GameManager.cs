using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoS_GameManager : MonoBehaviour
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
    [SerializeField] private GameObject scissors;
    [SerializeField] private GameObject tweezers;
    [SerializeField] private GameObject antisepticSwabs;
    [SerializeField] private GameObject tray;
    [SerializeField] private GameObject steriStrips;
    [SerializeField] private GameObject gloves;


<<<<<<< Updated upstream
=======


>>>>>>> Stashed changes
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
        audioSource.PlayOneShot(intro_VO[1]);
        yield return new WaitForSeconds(intro_VO[1].length);


        audioSource.PlayOneShot(intro_VO[2]);
        yield return new WaitForSeconds(intro_VO[2].length);

        audioSource.PlayOneShot(intro_VO[3]);
        yield return new WaitForSeconds(intro_VO[3].length);

        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);


        //Step 1
        Debug.Log("Play VO2");
        audioSource.PlayOneShot(intro_VO[5]);
        //   PlayGuide(0);                                               
        //Playing Hand Washing Animation.
        yield return new WaitForSeconds(intro_VO[5].length);

        Debug.Log("Play VO3");
        audioSource.PlayOneShot(intro_VO[6]);
        //   PlayGuide(1);                         
        //Playing Animation of procedure area getting cobered with curtains.
        yield return new WaitForSeconds(intro_VO[6].length);



        //Step 2: Show Equipments
        Debug.Log("Play VO4");
        audioSource.PlayOneShot(intro_VO[7]);
        yield return new WaitForSeconds(intro_VO[7].length);

        audioSource.PlayOneShot(intro_VO[8]);
        yield return new WaitForSeconds(intro_VO[8].length);

        audioSource.PlayOneShot(intro_VO[9]);
        yield return new WaitForSeconds(intro_VO[9].length);



        // Step 3 : Proper Body Mechanism
        Debug.Log("Play VO5");
        audioSource.PlayOneShot(intro_VO[10]);
        //    PlayGuide(2);    
        //Playing Animation of bed in semi-fold position and patient getting lie down on the back.
        yield return new WaitForSeconds(intro_VO[10].length);



        // Step 4: Wearing Gloves
        Debug.Log("Play VO6");
        audioSource.PlayOneShot(intro_VO[11]);
        //    PlayGuide(3);                           
        // Playing Animation of transparent hands wearing gloves.
        yield return new WaitForSeconds(intro_VO[11].length);
        gloves.GetComponent<BoxCollider>().enabled = true;
        gloves.GetComponent<Rigidbody>().useGravity = true;


    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream

=======
        
>>>>>>> Stashed changes
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
        gloves.GetComponent<BoxCollider>().enabled = false;
        scissors.GetComponent<BoxCollider>().enabled = false;
        tweezers.GetComponent<BoxCollider>().enabled = false;
        steriStrips.GetComponent<BoxCollider>().enabled = false;
        tray.GetComponent<BoxCollider>().enabled = false;
        antisepticSwabs.GetComponent<BoxCollider>().enabled = false;


        // 2) Disable all Gravity since Box Colliders are off
        gloves.GetComponent<Rigidbody>().useGravity = false;
        scissors.GetComponent<Rigidbody>().useGravity = false;
        tweezers.GetComponent<Rigidbody>().useGravity = false;
        steriStrips.GetComponent<Rigidbody>().useGravity = false;
        tray.GetComponent<Rigidbody>().useGravity = false;
        antisepticSwabs.GetComponent<Rigidbody>().useGravity = false;
    }
}
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
