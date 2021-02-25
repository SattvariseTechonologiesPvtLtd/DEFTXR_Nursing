using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSaline_Collision : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Saline_bag")
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(true);
        }
    }
}
