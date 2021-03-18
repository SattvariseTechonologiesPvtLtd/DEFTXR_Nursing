using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OAGAMEMANAGER : MonoBehaviour
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
    private GameObject WoldBottle;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
