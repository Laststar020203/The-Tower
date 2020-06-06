using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcChat : MonoBehaviour {

    public Transform playTr;
    private Transform tr;
    public Choice_KOR choice;

    public GameObject chat;


    public float distance = 10f;

	// Use this for initialization
	void Start () {

        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(tr.position, playTr.position) <= distance)
        {
            choice.Change();
            chat.SetActive(true);
        }
	}
}
