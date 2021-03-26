using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SteriWound2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Steri Strip 2") == 0)
        {
            Debug.Log("Collided");
            //Play Antiseptic Apply Animation 
            StartCoroutine(RS_GameManager.Instance.Step13_2());
        }

        Debug.Log("Not Collided with ");

    }
}
