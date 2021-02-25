using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBagCollision : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Blood_bag")
        {
            go1.SetActive(false);
            go2.SetActive(false);
            go3.SetActive(true);
        }

        StartCoroutine(BT_GameManager.Instance.step2());
    }
}

