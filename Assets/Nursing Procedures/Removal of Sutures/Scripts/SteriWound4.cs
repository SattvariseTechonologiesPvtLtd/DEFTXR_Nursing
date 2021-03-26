using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SteriWound4 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Steri Strip 1") == 0)
        {
            Debug.Log("Collided");
            //Play Antiseptic Apply Animation 
            StartCoroutine(RS_GameManager.Instance.Step28());
        }

        Debug.Log("Not Collided with ");

    }
}
