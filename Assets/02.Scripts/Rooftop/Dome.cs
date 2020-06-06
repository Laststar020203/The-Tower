using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dome : MonoBehaviour {
    private GameObject Manager;
    private float tempSpendTime;
    private void Start()
    {
        Manager = GameObject.Find("RoofTopManager");
        tempSpendTime = Manager.GetComponent<RoofTopManager>().SpendTime;
        StartCoroutine(Destroy_());
    }
    // Use this for initialization

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Manager.GetComponent<RoofTopManager>().SpendTime
                   *= 10;
        }
        //플레이어 이동속도 감속
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Manager.GetComponent<RoofTopManager>().SpendTime
                   = tempSpendTime;
        }
    }

    IEnumerator Destroy_(){
        yield return new WaitForSeconds(3);
        Manager.GetComponent<RoofTopManager>().SpendTime
               = tempSpendTime;
        Destroy(gameObject);
    }

}
