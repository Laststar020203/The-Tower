using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPiece : MonoBehaviour {

    public bool isHold = false;
    GameObject Manager;
	// Use this for initialization
	void Start () {
        Manager = GameObject.Find("RoofTopManager");
	}

    // Update is called once per frame
    void Update()
    {
        if (isHold == true)
        {
            gameObject.GetComponent<MeshRenderer>().material.color
                      = Color.blue;
        }
        else{
            gameObject.GetComponent<MeshRenderer>().material.color
                      = Color.red;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player")){
            isHold = true;
            Manager.GetComponent<RoofTopManager>().ClearConfig();
        }
    }
}
