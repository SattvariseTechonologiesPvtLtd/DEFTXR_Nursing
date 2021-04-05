using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SutureTweezerFinal : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Suture1 Highlight") == 0)
        { 
                StartCoroutine(RS_GameManager.Instance.Step6());
                Debug.Log("Collided"); 
        }
        else if (String.Compare(col.gameObject.name, "Suture2 Highlight") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step9());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "Suture3 Highlight") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step15());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "Suture4 Highlight") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step18());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "Suture5 Highlight") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step21());
            Debug.Log("Collided");
        }
        Debug.Log("Not Collided with ");
    }
}
