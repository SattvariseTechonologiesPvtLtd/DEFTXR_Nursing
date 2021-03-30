using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_Equipments : MonoBehaviour
{
    public static RT_Equipments Instance;

    public void Awake()
    {
        Instance = this;
    }

    //Original Equipments
    public GameObject NASOGASTRIC_TUBE;

    public GameObject MEASURE_TUBE;

    public GameObject Fix_Insertion_TUBE;

    public GameObject FIX_NASOGASTRIC_TUBE;

    public GameObject WATER_SOLUBLE_LUBRICANT;

    public GameObject GLASS_OF_WATER;

    public GameObject TAPE;

    public GameObject SmallTape;

    public GameObject EMESIS_BASIN;

}
