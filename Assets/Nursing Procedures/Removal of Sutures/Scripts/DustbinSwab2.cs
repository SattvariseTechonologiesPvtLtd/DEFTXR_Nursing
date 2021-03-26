using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DustbinSwab2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Antiseptic swab") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step24());
            Debug.Log("Collided");
        }

        Debug.Log("Not Collided with ");

    }
}
