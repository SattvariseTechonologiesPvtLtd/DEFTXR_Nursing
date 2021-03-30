using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_Highlighted : MonoBehaviour
{
    public static RT_Highlighted Instance;

    public void Awake()
    {
        Instance = this;
    }


    public GameObject NG_Highlighted;

    public GameObject Tape_Highlighted;

    public GameObject smallTape_Highlighted;

    public GameObject GOW_Highlighted;

    public GameObject WSL_Highlighted;

}
