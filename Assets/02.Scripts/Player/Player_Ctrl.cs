using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player_Ctrl : MonoBehaviour {

    #region Var
    private Transform playerTr;
    private Rigidbody rbody;
    private Vector3 targetPos;
    private NavMeshAgent playerNav;
    private float moveDis;
    private Animator anim;
	AudioSource audioSource;
	AudioClip[] clips; //0 scream 1 walking
	AudioClip playClip;
	#endregion


    // Use this for initialization
    private void Start()
    {
        playerTr = gameObject.GetComponent<Transform>();
        playerNav = gameObject.GetComponent<NavMeshAgent>();
        rbody = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        moveDis = 1.0f;
        targetPos = playerTr.position;
		audioSource = GetComponent<AudioSource> ();

    }
    // Update is called once per frame
    private void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                targetPos = hit.point;
            }

            playerTr.LookAt(targetPos);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move() // Call target position, player move to ther position
    {
        float target = Vector3.Distance(playerTr.position, targetPos);

        playerNav.destination = targetPos;
        if (target >= moveDis)
        {
            anim.SetBool("isMove",true);

        }
        else
        {
            anim.SetBool("isMove",false);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(targetPos,0.4f);
    }

	public void Scream(){
		playClip = clips [0];
		audioSource.clip = playClip;
		audioSource.Play ();
	}
	public void Walking(){
		playClip = clips [1];
		audioSource.clip = playClip;
		audioSource.Play ();

	}
}
