using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBagCollision : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Blood_bag")
        {
            Debug.Log("Collided");

            originalObj.Instance.BloodBag_IVPole.SetActive(true);
            originalObj.Instance.Blood_Bag.SetActive(false);

            BT_GameManager.Instance.leftHandGrab.GrabEnd();

            StartCoroutine(BT_GameManager.Instance.Step8());
            highlightObj.Instance.BloodBag_IVPole_Highlighted.SetActive(false);

        }
    }
}

