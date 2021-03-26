using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DustbinSwab : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Antiseptic swab") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step3());
            Debug.Log("Collided");
        }

        Debug.Log("Not Collided with ");

    }
}
