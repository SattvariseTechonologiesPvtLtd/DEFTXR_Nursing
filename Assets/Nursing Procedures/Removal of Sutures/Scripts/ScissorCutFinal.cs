using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScissorCutFinal : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "CutGuide1") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step7());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "CutGuide2") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step10());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "CutGuide3") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step16());
            Debug.Log("Collided");
        }
        else if (String.Compare(col.gameObject.name, "CutGuide4") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step19());
            Debug.Log("Collided");
        }
        else if(String.Compare(col.gameObject.name, "CutGuide5") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step22());
            Debug.Log("Collided");
        }
        Debug.Log("Not Collided with ");
    }
}
