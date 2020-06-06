using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaMove : MonoBehaviour {

    private Transform tr;
    private float x;
    private float z;
    private Vector3 move;
    private Vector3 moves;
    private Rigidbody rb;

    public bool isSturn = false;

    public float speed;



    public bool isMove = true;

    private void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
      //  gravityChange = GetComponent<GravityChange>();
    }

    private void Update()
    {



                       Move();

            Turn();
        
    }
   
    private void Move()
    {
        
        if (!isMove || isSturn) return;
       

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        
        
        
        move = (Vector3.right * x) + (Vector3.forward * z);




        tr.Translate(move.normalized * Time.deltaTime * speed );
             
    }
    void Turn()
    {
       if (x == 0 && z == 0) return;
      

     

       


      
      

    }

}
