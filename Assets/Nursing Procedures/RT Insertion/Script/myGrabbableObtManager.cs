using UnityEngine;
using System.Collections;
using System;

public class myGrabbableObtManager : MonoBehaviour
{
    public GameObject myGrabbaleObj;


    public void OnTriggerEnter(Collider other)
    {
        if (String.Compare(other.gameObject.name, "touchInput") == 0)
        {
            Debug.Log("workinggggg");

            myGrabbaleObj.SetActive(true);
            myGrabbaleObj.GetComponent<BoxCollider>().enabled = true;
            myGrabbaleObj.GetComponent<Rigidbody>().useGravity = true;
            myGrabbaleObj.GetComponent<Rigidbody>().isKinematic = false;

            BT_GameManager.Instance.touch_input.SetActive(false);

            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("not working");
        }
    }

 
}
