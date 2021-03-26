using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WoundAntiseptic2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Antiseptic swab") == 0)
        { 
            Debug.Log("Collided");
            //Play Antiseptic Apply Animation 
            StartCoroutine(RS_GameManager.Instance.Step11());
        }

        Debug.Log("Not Collided with ");

    }

}
