using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScissorCut3 : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Scissor") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step19());
            Debug.Log("Collided");
        }
        Debug.Log("Not Collided with ");
    }
}
