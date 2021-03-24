using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushBagFinalTube_Collision : MonoBehaviour
{


    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Saline_static_tube")
        {
            originalObj.Instance.FlushBag_SalineTube.SetActive(true);
            originalObj.Instance.SalineTube_Static.SetActive(false);
           

            BT_GameManager.Instance.leftHandGrab.GrabEnd();

            StartCoroutine(BT_GameManager.Instance.Step6());
            highlightObj.Instance.FlushBag_SalineTube_Highlighted.SetActive(false);
        }

        
       
    }
}
