using UnityEngine;
using System.Collections;

public class originalObj : MonoBehaviour
{
    public static originalObj Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Grababble Apparatus
    [SerializeField]
    public GameObject Alcohol_Pads;
    [SerializeField]
    public GameObject Blood_Bag;
    [SerializeField]
    public GameObject Normal_Saline;
    [SerializeField]
    public GameObject Syringe;
    [SerializeField]
    public GameObject BloodBag_IVPole;
    [SerializeField]
    public GameObject NormalSaline_IVPole;
    [SerializeField]
    public GameObject CannulaIV_Final;
    [SerializeField]
    public GameObject CannulaIV_Static;
    [SerializeField]
    public GameObject SalineTube_Static;
    [SerializeField]
    public GameObject SalineTube_Static_2;
    [SerializeField]
    public GameObject BloodBag_SalineTube;
    [SerializeField]
    public GameObject FlushBag_SalineTube;

}
