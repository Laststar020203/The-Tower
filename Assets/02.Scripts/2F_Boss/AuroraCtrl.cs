using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraCtrl : MonoBehaviour {


    Transform tr;
    public float speed = 120f;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }
    // Use this for initialization
    void Update () {

        tr.Translate(Vector3.forward * speed * Time.deltaTime);

	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER")) ;
            Manager_Boss2.instance.HitPlayer();

    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("PLAYER"))
            Manager_Boss2.instance.HitPlayer();
    }



}
