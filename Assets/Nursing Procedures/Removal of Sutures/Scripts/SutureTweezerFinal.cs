using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SutureTweezerFinal : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "SutureKnot1") == 0)
        { 
                StartCoroutine(RS_GameManager.Instance.Step6());
                Debug.Log("Collided"); 
        }
        else if (String.Compare(col.gameObject.name, "SutureKnot2") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step9());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "SutureKnot3") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step15());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "SutureKnot4") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step18());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "SutureKnot5") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step21());
            Debug.Log("Collided");
        }
        Debug.Log("Not Collided with ");
    }
}
