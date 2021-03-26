using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TrayReplace : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if (String.Compare(col.gameObject.name, "Tray") == 0)
        {
            StartCoroutine(RS_GameManager.Instance.Step4());
            Debug.Log("Collided");
        }
        Debug.Log("Not Collided with ");
    }
}
