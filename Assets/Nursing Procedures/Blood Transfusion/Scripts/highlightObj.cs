using UnityEngine;
using System.Collections;

public class highlightObj : MonoBehaviour
{
    public static highlightObj Instance;

    public void Awake()
    {
        Instance = this;
    }

    //List of Highlighted Equipments
    [SerializeField]
    public GameObject Alcohol_Pads_Highlighted;
    [SerializeField]
    public GameObject Blood_Bag_Highlighted;
    [SerializeField]
    public GameObject Normal_Saline_Highlighted;
    [SerializeField]
    public GameObject Syringe_Highlighted;
    [SerializeField]
    public GameObject BloodBag_IVPole_Highlighted;
    [SerializeField]
    public GameObject NormalSaline_IVPole_Highlighted;
    [SerializeField]
    public GameObject CannulaIV_Final_Highlighted;
    [SerializeField]
    public GameObject CannulaIV_Static_Highlighted;
    [SerializeField]
    public GameObject SalineTube_Static_Highlighted;
    [SerializeField]
    public GameObject SalineTube_Static_Highlighted_2;
    [SerializeField]
    public GameObject BloodBag_SalineTube_Highlighted;
    [SerializeField]
    public GameObject FlushBag_SalineTube_Highlighted;

}
