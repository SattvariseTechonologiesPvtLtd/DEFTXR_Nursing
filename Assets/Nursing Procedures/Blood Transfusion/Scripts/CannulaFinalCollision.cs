using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CannulaFinalCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "CannulaIV_Static") == 0)
        {
            Debug.Log("Collided");
            StartCoroutine(BT_GameManager.Instance.Step2());
        }

            Debug.Log("Not Collided with ");
        
    }
   
}
