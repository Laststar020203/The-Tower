using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Move : MonoBehaviour {
    Vector3 bet;
    bool outPoint = false;
    Transform tr;
    Rigidbody rb;
    public float speed = 30f;
    public float rotSpeed = 50f;

	bool isYunsan;


    
    public bool isStop = false;

    Animator anim;
	bool isTruning=false;
    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
       anim = GetComponent<Animator>();
    }   // Update is called once per frame
    void Update()
	{

		if (isStop)
			return;

		float z = Input.GetAxisRaw ("Vertical");
		float x = Input.GetAxisRaw ("Horizontal");

		Vector3 move = (tr.forward * z) + (tr.right * x);

		//Debug.Log (move);
		 //rb.AddForce(move.normalized * Time.deltaTime * speed);
		//rb.velocity = move.normalized * Time.deltaTime * speed;

		// anim.SetBool("IsMoving" ,(z != 0 || x != 0));

		if (z == 0 && x == 0)
			return;

		if (!isTruning)
			StartCoroutine (Turn (move));
	}

	float t=0;
    IEnumerator Turn(Vector3 move)
	{
		isTruning = true;
		while (t <= 1)
		{
			Debug.Log(t);
			Quaternion newRotation = Quaternion.LookRotation (move);
			tr.rotation = Quaternion.Slerp (tr.rotation, newRotation, t);
			t += Time.deltaTime * 5f;
			yield return null;
		}
		t = 0;
		isTruning = false;
	}




}
