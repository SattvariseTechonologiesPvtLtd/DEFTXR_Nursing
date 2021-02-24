using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject Highlighted;
    public GameObject go2;
    public GameObject go3;
  

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Highlighted"))
        {

            this.gameObject.SetActive(false);
            go2.SetActive(false);
           

            go3.SetActive(true);
        }
    }
}
