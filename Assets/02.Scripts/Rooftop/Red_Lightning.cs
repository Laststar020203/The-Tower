using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Lightning : Lightning{
    [SerializeField]
    private GameObject Dome;
    private GameObject Manager;
	// Use this for initialization
	void Start () {
        Manager = GameObject.Find("RoofTopManager");
        base.Dome = Dome;
        base.CreateDome();
        base.Deaths();
	}

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            Manager.GetComponent<RoofTopManager>().SpendTime *= 2;
    }
}
