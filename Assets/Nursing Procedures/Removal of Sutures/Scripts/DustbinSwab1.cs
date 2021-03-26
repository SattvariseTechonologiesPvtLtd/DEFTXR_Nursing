using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DustbinSwab1 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Antiseptic swab") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step11_2());
            Debug.Log("Collided");
        }

        Debug.Log("Not Collided with ");

    }
}
