﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reg_Replace : MonoBehaviour
{

    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Regulator")
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(true);
        }
    }
}
