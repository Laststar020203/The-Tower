using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class FootHoldCtrl : MonoBehaviour
{

    Rigidbody rb;
    public bool isFall = false;
    MeshRenderer ms;
    public float hidenTime = 2f;
    float a;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        ms = GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (isFall)
        {
            rb.useGravity = true;
   
            rb.isKinematic = false;
        }
	}
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("PLAYER"))
        {       
            int word = Int32.Parse(this.gameObject.name);
            Debug.Log(word);
            Manager_FootHoldTrap.instance.inputNumber(word, this);  
        }
    }
   
    
}
