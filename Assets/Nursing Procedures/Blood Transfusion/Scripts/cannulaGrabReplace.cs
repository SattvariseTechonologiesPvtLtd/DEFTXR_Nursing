using UnityEngine;
using System.Collections;
using System;

public class cannulaGrabReplace : MonoBehaviour
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
            this.gameObject.SetActive(false); 
        }   
        else
        {
            Debug.Log("not working");
        }
    }
}
