using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_GameManager : MonoBehaviour
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
        RT_Animations.Instance.character_animation.GetComponent<Animator>().Play("Eyeblink_Talk_clone");
        yield return new WaitForSeconds(intro_VO[7].length);

        //wash Handswash
        audioSource.PlayOneShot(intro_VO[8]);
        Guides[1].SetActive(true);
        RT_Animations.Instance.pushHand_animation.SetActive(true);
        RT_Animations.Instance.washHand_animation.SetActive(true);
        yield return new WaitForSeconds(intro_VO[8].length);
        RT_Animations.Instance.pushHand_animation.GetComponent<Animator>().Play("Hand_push_anim_clone");
        RT_Animations.Instance.washHand_animation.GetComponent<Animator>().Play("Hand_wash_anim_clone");
        yield return new WaitForSeconds(3f);
        RT_Animations.Instance.pushHand_animation.SetActive(false);
        RT_Animations.Instance.washHand_animation.SetActive(false);
        Guides[1].SetActive(false);
        yield return new WaitForSeconds(5f);

        audioSource.PlayOneShot(intro_VO[9]);
        Guides[2].SetActive(true);
        yield return new WaitForSeconds(intro_VO[9].length);
        RT_Animations.Instance.character_animation.GetComponent<Animator>().Play("Getup_idle_clone");
        yield return new WaitForSeconds(3f);
        RT_Animations.Instance.bed_animation.GetComponent<Animator>().Play("Mattress_rotation2_clone");
        yield return new WaitForSeconds(3f);
        RT_Animations.Instance.character_animation.GetComponent<Animator>().Play("Leaning_back_clone");
        yield return new WaitForSeconds(3f);
        Guides[2].SetActive(false);
        Guides[3].SetActive(true);

        //Enable NASOGASTRIC_TUBE
        RT_Highlighted.Instance.NG_Highlighted.SetActive(true);
        RT_Equipments.Instance.NASOGASTRIC_TUBE.SetActive(false);
        RT_Equipments.Instance.NASOGASTRIC_TUBE.GetComponent<BoxCollider>().enabled = true;
        RT_Equipments.Instance.NASOGASTRIC_TUBE.GetComponent<Rigidbody>().useGravity = true;

    }

    void Update()
    {
        if (RT_Equipments.Instance.NASOGASTRIC_TUBE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[1] == false)
        {
            RT_Labels.Instance.NGTUBE_Name.SetActive(false); 
            Guides[3].SetActive(false);
            Guides[4].SetActive(true);
            RT_Equipments.Instance.MEASURE_TUBE.SetActive(true);
            RT_Animations.Instance.measure_animation.SetActive(true);
            StartCoroutine(Step1());
            ActionsCompleted[1] = true;

            RT_Highlighted.Instance.Tape_Highlighted.SetActive(true);
            RT_Equipments.Instance.TAPE.SetActive(false);
            RT_Equipments.Instance.TAPE.GetComponent<BoxCollider>().enabled = true;
            RT_Equipments.Instance.TAPE.GetComponent<Rigidbody>().useGravity = true;
        }

        if (RT_Equipments.Instance.TAPE.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[2] == false)
        {
            RT_Labels.Instance.Tape_Name.SetActive(false);
            Guides[11].SetActive(false);
            StartCoroutine(Step2());
            ActionsCompleted[2] = true;

            RT_Equipments.Instance.WATER_SOLUBLE_LUBRICANT.GetComponent<BoxCollider>().enabled = true;
            RT_Equipments.Instance.WATER_SOLUBLE_LUBRICANT.GetComponent<Rigidbody>().useGravity = true;

        }

        if (RT_Equipments.Instance.WATER_SOLUBLE_LUBRICANT.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[3] == false)
        {
            RT_Labels.Instance.WSL_Name.SetActive(false);
            Guides[12].SetActive(false);
            StartCoroutine(Step3());
            ActionsCompleted[3] = true;

            RT_Equipments.Instance.GLASS_OF_WATER.GetComponent<BoxCollider>().enabled = true;
            RT_Equipments.Instance.GLASS_OF_WATER.GetComponent<Rigidbody>().useGravity = true;
        }

        if (RT_Equipments.Instance.GLASS_OF_WATER.GetComponent<OVRGrabbable>().isGrabbed == true && ActionsCompleted[4] == false)
        {
            RT_Labels.Instance.GOW_Name.SetActive(false);
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

        RT_Equipments.Instance.NASOGASTRIC_TUBE.SetActive(true);
        RT_Equipments.Instance.TAPE.SetActive(true);
        RT_Equipments.Instance.WATER_SOLUBLE_LUBRICANT.SetActive(true);
        RT_Equipments.Instance.GLASS_OF_WATER.SetActive(true);
        RT_Equipments.Instance.SmallTape.SetActive(false);
        RT_Highlighted.Instance.smallTape_Highlighted.SetActive(false);
        //Disable all Interactables/Grabbable property of GrabbableObjects, except 1st

        // 1) Disable all Box Colliders to avoid getting grabbed.
        RT_Equipments.Instance.NASOGASTRIC_TUBE.GetComponent<BoxCollider>().enabled = false;
        RT_Equipments.Instance.WATER_SOLUBLE_LUBRICANT.GetComponent<BoxCollider>().enabled = false;
        RT_Equipments.Instance.GLASS_OF_WATER.GetComponent<BoxCollider>().enabled = false;
        RT_Equipments.Instance.TAPE.GetComponent<BoxCollider>().enabled = false;


        // 2) Disable all Gravity since Box Colliders are off
        RT_Equipments.Instance.NASOGASTRIC_TUBE.GetComponent<Rigidbody>().useGravity = false;
        RT_Equipments.Instance.WATER_SOLUBLE_LUBRICANT.GetComponent<Rigidbody>().useGravity = false;
        RT_Equipments.Instance.GLASS_OF_WATER.GetComponent<Rigidbody>().useGravity = false;
        RT_Equipments.Instance.TAPE.GetComponent<Rigidbody>().useGravity = false;
    
    }

   

    IEnumerator Step1()
    {
        // STEP 1 Pick Nasogastric Tube

        audioSource.PlayOneShot(intro_VO[10]);
        RT_Animations.Instance.measure_animation.GetComponent<Animator>().Play("Hand_measure");
        yield return new WaitForSeconds(intro_VO[10].length);
        Guides[4].SetActive(false);
        RT_Equipments.Instance.MEASURE_TUBE.SetActive(false);
        RT_Animations.Instance.measure_animation.SetActive(false);
        Guides[11].SetActive(true);

    }

    IEnumerator Step2()
    {
        // step 2 Highlight Tape and Attach to Nasogastric Tube
        Guides[5].SetActive(true);
        audioSource.PlayOneShot(intro_VO[11]);
        yield return new WaitForSeconds(intro_VO[11].length);
        Guides[5].SetActive(false);
        Guides[13].SetActive(true);
        RT_Highlighted.Instance.smallTape_Highlighted.SetActive(true);
        yield return new WaitForSeconds(5f);
        Guides[13].SetActive(false);
        Guides[12].SetActive(true);
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
        RT_Equipments.Instance.Fix_Insertion_TUBE.SetActive(true);
        RT_Animations.Instance.tube_insert_animation.SetActive(true);
        RT_Animations.Instance.tube_insert_animation.GetComponent<Animator>().Play("Hand_insertTube_movement");
        RT_Animations.Instance.character_animation.GetComponent<Animator>().Play("Rising_head_forTubeInsertion_clone");
        yield return new WaitForSeconds(intro_VO[13].length);
        Guides[7].SetActive(false);
        RT_Animations.Instance.tube_insert_animation.SetActive(false);
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
        RT_Animations.Instance.character_animation.GetComponent<Animator>().Play("Drinking_water_after_Discomfort_clone");
        yield return new WaitForSeconds(intro_VO[15].length);

        Guides[9].SetActive(false);
        yield return new WaitForSeconds(3f);

        Guides[14].SetActive(true);
        RT_Equipments.Instance.Fix_Insertion_TUBE.SetActive(false);
        yield return new WaitForSeconds(3f);
        Guides[14].SetActive(false);

        Guides[10].SetActive(true);
        RT_Equipments.Instance.FIX_NASOGASTRIC_TUBE.SetActive(true);
        audioSource.PlayOneShot(intro_VO[16]);
        yield return new WaitForSeconds(intro_VO[16].length);
        Guides[10].SetActive(false);

    }
}
