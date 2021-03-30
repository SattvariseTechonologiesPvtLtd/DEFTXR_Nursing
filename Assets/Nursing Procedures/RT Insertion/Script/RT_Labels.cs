using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_Labels : MonoBehaviour
{
    public static RT_Labels Instance;

    public void Awake()
    {
        Instance = this;
    }

    //Labels
    public GameObject NGTUBE_Name;
    public GameObject Tape_Name;
    public GameObject WSL_Name;
    public GameObject GOW_Name;

}
