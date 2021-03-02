using UnityEngine;
using System.Collections;

public class equipmentLabels : MonoBehaviour
{
    public static equipmentLabels Instance;

    public void Awake()
    {
        Instance = this;
    }

    //Labels
    [SerializeField]
    public GameObject BloodBag_Name;
    [SerializeField]
    public GameObject NormalSaline_Name;
    [SerializeField]
    public GameObject CannulaIV_Name;
    [SerializeField]
    public GameObject IVTube_Name;
    [SerializeField]
    public GameObject Syringe_Name;
    [SerializeField]
    public GameObject alcoholPad_Name;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
