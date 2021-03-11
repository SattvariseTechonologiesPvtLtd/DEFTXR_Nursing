using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBagFInalTube_Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Saline_static_tube_2")
        {
            originalObj.Instance.BloodBag_SalineTube.SetActive(true);
            originalObj.Instance.SalineTube_Static_2.SetActive(false);
            originalObj.Instance.FlushBag_SalineTube.SetActive(false);

            BT_GameManager.Instance.leftHandGrab.GrabEnd();

            StartCoroutine(BT_GameManager.Instance.Step10());
            highlightObj.Instance.BloodBag_SalineTube_Highlighted.SetActive(false);

        }



    }
}
