﻿using UnityEngine;
using System.Collections;

public class TapeCollision : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "NGTube_grabbable")
        {
           this.gameObject.SetActive(false);
        }
    }
}
