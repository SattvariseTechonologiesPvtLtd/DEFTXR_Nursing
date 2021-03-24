using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ET_GameManager : MonoBehaviour
{
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

    // Model of Patient lying on Bed
    [SerializeField]
    private GameObject patient;

    private bool grabbedOnce1 = false;
    private bool grabbedOnce2 = false;
    private bool grabbedOnce3 = false;
    private bool grabbedOnce4 = false;

    // Grababble Apparatus
    [SerializeField]
    private GameObject Drawer_1;
    [SerializeField]
    private GameObject Drawer_2;
    [SerializeField]
    private GameObject Drawer_3;
    [SerializeField]
    private GameObject Drawer_4;
    [SerializeField]
    private GameObject Drawer_5;
    [SerializeField]
    private GameObject Drawer_6;
    [SerializeField]

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

        //Show Apparatus
        audioSource.PlayOneShot(intro_VO[4]);
        yield return new WaitForSeconds(intro_VO[4].length);
        yield return new WaitForSeconds(4f);

        audioSource.PlayOneShot(intro_VO[5]);
        Guides[0].SetActive(true);
        yield return new WaitForSeconds(intro_VO[5].length);
        audioSource.PlayOneShot(intro_VO[6]);
        yield return new WaitForSeconds(intro_VO[6].length);
        Guides[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        audioSource.PlayOneShot(intro_VO[7]);
        yield return new WaitForSeconds(intro_VO[7].length);

     
        audioSource.PlayOneShot(intro_VO[8]);
        Guides[1].SetActive(true);

        yield return new WaitForSeconds(intro_VO[8].length);

        yield return new WaitForSeconds(3f);

        Guides[1].SetActive(false);
        yield return new WaitForSeconds(5f);



        audioSource.PlayOneShot(intro_VO[9]);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[9].length);
    
        yield return new WaitForSeconds(3f);

        yield return new WaitForSeconds(3f);
    
        yield return new WaitForSeconds(3f);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);

        Drawer_1.SetActive(false);
        Drawer_1.GetComponent<BoxCollider>().enabled = true;
        Drawer_1.GetComponent<Rigidbody>().useGravity = true;

    }

    void Update()
    {
        if (Drawer_1.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {
            
            Guides[3].SetActive(false);
            Guides[4].SetActive(true);
            Drawer_2.SetActive(true);
            StartCoroutine(Step1());
            ActionsCompleted[1] = true;


        }

        
        {
        
            Guides[11].SetActive(false);
            StartCoroutine(Step2());
            ActionsCompleted[2] = true;

            Drawer_5.GetComponent<BoxCollider>().enabled = true;
            Drawer_5.GetComponent<Rigidbody>().useGravity = true;

        }

        if (Drawer_5.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
        
            Guides[12].SetActive(false);
            StartCoroutine(Step3());
            ActionsCompleted[3] = true;

            Drawer_6.GetComponent<BoxCollider>().enabled = true;
            Drawer_6.GetComponent<Rigidbody>().useGravity = true;
        }

        if (Drawer_6.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false)
        {
         
            Guides[15].SetActive(false);
            StartCoroutine(Step4());
            ActionsCompleted[4] = true;
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

        Drawer_1.SetActive(true);
       
        Drawer_5.SetActive(true);
        Drawer_6.SetActive(true);
      
        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        Drawer_1.GetComponent<BoxCollider>().enabled = false;
        Drawer_5.GetComponent<BoxCollider>().enabled = false;
        Drawer_6.GetComponent<BoxCollider>().enabled = false;
      


        // 2) Disable all Gravity since Box Colliders are off
        Drawer_1.GetComponent<Rigidbody>().useGravity = false;
        Drawer_5.GetComponent<Rigidbody>().useGravity = false;
        Drawer_6.GetComponent<Rigidbody>().useGravity = false;
        
    
    }

   

    IEnumerator Step1()
    {
   

        audioSource.PlayOneShot(intro_VO[10]); 

        yield return new WaitForSeconds(intro_VO[10].length);
        Guides[4].SetActive(false);
        Drawer_2.SetActive(false);
        
        Guides[11].SetActive(true);

    }

    IEnumerator Step2()
    {
       
        Guides[5].SetActive(true);
        audioSource.PlayOneShot(intro_VO[11]);
        yield return new WaitForSeconds(intro_VO[11].length);
        Guides[5].SetActive(false);
        Guides[13].SetActive(true);
     
        yield return new WaitForSeconds(5f);
        Guides[13].SetActive(false);
        Guides[12].SetActive(true);
    }

    IEnumerator Step3()
    {

        Guides[6].SetActive(true);
        audioSource.PlayOneShot(intro_VO[12]);
        yield return new WaitForSeconds(intro_VO[12].length);
        Guides[6].SetActive(false);
        yield return new WaitForSeconds(4f);


        Guides[7].SetActive(true);
        audioSource.PlayOneShot(intro_VO[13]);
        Drawer_3.SetActive(true);
     
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
        Drawer_3.SetActive(false);
        yield return new WaitForSeconds(3f);
        Guides[14].SetActive(false);

        Guides[10].SetActive(true);
        Drawer_4.SetActive(true);
        audioSource.PlayOneShot(intro_VO[16]);
        yield return new WaitForSeconds(intro_VO[16].length);
        Guides[10].SetActive(false);

    }
}
