﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SutureTweezer2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Tweezers") == 0)
        { 
                StartCoroutine(RS_GameManager.Instance.Step15());
                Debug.Log("Collided"); 
        }
        Debug.Log("Not Collided with ");
    }
}
