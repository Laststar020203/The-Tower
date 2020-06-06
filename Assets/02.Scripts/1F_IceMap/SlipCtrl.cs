using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipCtrl : MonoBehaviour {

    Transform tr;
    public Vector3 location;
    Debug_Move _move;
    Debug_ClickMovementCtrl _click;
    public bool isGoing = false;
    [SerializeField] private LayerMask layer;
    Rigidbody rb;
    public float speed = 50f;

    bool inWall = false;
    bool inWall2 = false;
    bool inWall3 = false;
    bool inWall4 = false;
    bool inWallC = false;
    bool NearWall = false;


    

    private void Start()
    {
        tr = GetComponent<Transform>();
        _move = GetComponent<Debug_Move>();
        rb = GetComponent<Rigidbody>();
        //_click = GetComponent<Debug_ClickMovementCtrl>();

        
    }

    private void Update()
    {
    

        RaycastHit hit;
      
        if (Physics.Raycast(tr.position , -tr.up ,out hit, Mathf.Infinity , layer))
        {
            

            if (isGoing)
            {
                rb.MovePosition(tr.position + new Vector3(location.x , 0 ,location.z) * Time.deltaTime * speed);
            }

        }

       
    }

    private void OnTriggerEnter(Collider coll)
    {
		Debug.Log("OnTriggerEnter : " + coll.gameObject.tag);
		Debug.Log ("OnTriggerEnter : " + coll.gameObject.name);
        if (coll.CompareTag("POINT"))
        {
            inWall = false;
            inWall2 = false;
            inWall3 = false;
            inWall4 = false;
            inWallC = false;

            Debug.Log("Enter");
            FootEnterAction(coll);


        }
        if (coll.CompareTag("WALL"))
        {
            if (inWall || inWallC) return;
            inWallC = false;
            inWall4 = false;
            FootEnterAction(coll);

        }
        if (coll.CompareTag("WALL2"))
        {
            if (inWall2 || inWallC) return;
            inWall3 = false;
            inWallC = false;
            FootEnterAction(coll);
        }
        if (coll.CompareTag("WALL3"))
        {
            if (inWall3 || inWallC) return;
            inWall2 = false;
            inWallC = false;
            FootEnterAction(coll);

        }
        if (coll.CompareTag("WALL4"))
        {
            if (inWall4 || inWallC) return;
            inWall = false;
            inWallC = false;
            FootEnterAction(coll);

        }
        if (coll.CompareTag("WALLC"))
        {
            inWallC = false;
            FootEnterAction(coll);

        }


    }


    private void OnTriggerExit(Collider coll)
    {

		Debug.Log("OnTriggerExit : "+coll.gameObject.tag);
		Debug.Log ("OnTriggerExit : " + coll.gameObject.name);

        if (coll.CompareTag("POINT"))
        {
            Debug.Log("Exit");

            _move.isStop = true;
            //_click.isMove = false;
            isGoing = true;
            location = (transform.position - coll.transform.position);

            if (Mathf.Abs(location.x) > Mathf.Abs(location.z))
            {
                location.z = 0;
            }
            else if (Mathf.Abs(location.x) < Mathf.Abs(location.z))
            {
                location.x = 0;
            }
        }
        if (coll.CompareTag("WALLC"))
        {
            FootExitAction();

            inWallC = true;
        }
        if (coll.CompareTag("WALL"))
        {
            if (inWall) return;
            FootExitAction();
            inWall = true;

        }
        if (coll.CompareTag("WALL2"))
        {
            if (inWall2) return;
            FootExitAction();
            inWall2 = true;

        }
        if (coll.CompareTag("WALL3"))
        {
            if (inWall3) return;
            FootExitAction();
            inWall3 = true;

        }
        if (coll.CompareTag("WALL4"))
        {
            if (inWall4) return;
            FootExitAction();

            inWall4 = true;

        }

       
    }
    
    void FootExitAction()
    {
		Debug.Log ("FootExitAction");
        _move.isStop = true;
        //_click.isMove = false;
        isGoing = true;

        if (Mathf.Abs(location.x) > Mathf.Abs(location.z))
        {
            location.z = 0;
        }
        else if (Mathf.Abs(location.x) < Mathf.Abs(location.z))
        {
            location.x = 0;
        }
    }

    void FootEnterAction(Collider coll)
    {
		Debug.Log ("FootEnterAction");
        isGoing = false;
        _move.isStop = false;

        tr.position = coll.gameObject.transform.position;
    }

}

