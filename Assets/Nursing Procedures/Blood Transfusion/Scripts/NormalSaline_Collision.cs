using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSaline_Collision : MonoBehaviour
{
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "Saline_bag")
        {
            go3.SetActive(true);
            go1.SetActive(false);
            go2.SetActive(false);

        }

       // StartCoroutine(BT_GameManager.Instance.Step4());
        Destroy(gameObject);
    }
}
