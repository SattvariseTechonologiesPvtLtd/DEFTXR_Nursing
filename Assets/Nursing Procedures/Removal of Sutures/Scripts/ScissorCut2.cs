using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScissorCut2 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Scissor") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step16());
            Debug.Log("Collided");
        }
        Debug.Log("Not Collided with ");
    }
}
