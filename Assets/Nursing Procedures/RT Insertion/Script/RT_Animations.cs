using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_Animations : MonoBehaviour
{
    public static RT_Animations Instance;

    public void Awake()
    {
        Instance = this;
    }

    public GameObject character_animation;
    public GameObject bed_animation;
    public GameObject pushHand_animation;
    public GameObject washHand_animation;
    public GameObject measure_animation;
    public GameObject tube_insert_animation;
}
