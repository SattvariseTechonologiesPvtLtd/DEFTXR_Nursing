using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannulaFinalCollision : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Cannula_IV_static")
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(true);
            
        }
        StartCoroutine(BT_GameManager.Instance.Step2());
        Destroy(this.gameObject);
    }
}
