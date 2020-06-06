using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YandereRoomAction : MonoBehaviour {

    Transform tr;
    Rigidbody rb;
   

   // CharaMove cm;
   // CharaCtrl _charaCtrl;

    Debug_Move dm;
    TouchMove tm;

    //pullCtrl--------------------------------------------------------------------------------------------------------------//
    Vector3 pullDirection;


    public float pullPower = 50;
    public float pullHeight = 5;
    private float pullCompareTime = 0;
    public float pullStuntTime = 5f;

    private bool onPush = false;
    private bool isCollision = false;
    //pullCtrl----------------------------------------------------------------------------------------------------------------//


    //gravity--------------------------------------------------------------------------------------------------------------//
    [HideInInspector]
    public Animator anim;
 
   
    public readonly int hashFlyGravity = Animator.StringToHash("FlyGravity");
    
    //gravity--------------------------------------------------------------------------------------------------------------//




    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tm = GetComponent<TouchMove>();
        //_charaCtrl = GetComponent<CharaCtrl>();
        anim = GetComponentInChildren<Animator>();
      
      
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Manager_Yandere.instance.isdamping)
        {
            anim.SetTrigger(hashFlyGravity);
            Debug.Log("hi");
        }
        */
        //pullCtrl----------------------------------------------------------------------------------------------------------------//


        //pullCtrl----------------------------------------------------------------------------------------------------------------//

        //gravity--------------------------------------------------------------------------------------------------------------//
        /*
        if (_gravityCtrl.isdamping)
        {
            if (OnTime) return;
            anim.SetTrigger(hashFlyGravity);
            OnTime = true;
        }
        else
        {
            OnTime = false;
        }
        */



        //gravity--------------------------------------------------------------------------------------------------------------//
      

    }

    private void OnCollisionEnter(Collision coll)
    {
        if (tm.isStop) return;
        if (coll.collider.CompareTag("MONSTER"))
        {

            

          StartCoroutine(  Pull(coll));
            Debug.Log("1");
        }     
    }
    IEnumerator Pull(Collision coll)
    {
        pullDirection = transform.position - coll.gameObject.transform.position + new Vector3(0, pullHeight, 0);
        rb.AddForce(pullDirection * pullPower, ForceMode.Impulse);
        Debug.Log("hit");
        dm.isStop = true;
        yield return new WaitForSeconds(pullStuntTime);
        
        dm.isStop = false;


       
    }

    }



