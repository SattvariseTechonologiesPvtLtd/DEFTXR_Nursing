using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSaline_Collision : MonoBehaviour
{
 

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Saline_bag")
        {
            Debug.Log("Collided");

            originalObj.Instance.NormalSaline_IVPole.SetActive(true);
            originalObj.Instance.Normal_Saline.SetActive(false);
            

            BT_GameManager.Instance.leftHandGrab.GrabEnd();

            StartCoroutine(BT_GameManager.Instance.Step4());
            highlightObj.Instance.NormalSaline_IVPole_Highlighted.SetActive(false);
        }

        
      
    }
}
