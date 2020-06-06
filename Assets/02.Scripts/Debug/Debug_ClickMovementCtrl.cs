using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_ClickMovementCtrl : MonoBehaviour {


    [SerializeField] private float _velocity = 50.0f;
    [SerializeField] private LayerMask _layer;

    SlipCtrl slip;


    Animator anim;

    private readonly int hashIsRun = Animator.StringToHash("IsRun");
    private readonly int hashJump = Animator.StringToHash("Jump");

    private CharacterController _controller;
    public bool isMove = false;
    private Vector3 _destination = new Vector3(0, 0, 0);

    private Rigidbody rb;
    private Transform tr;
    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        isMove = false;
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        slip = GetComponent<SlipCtrl>();
        anim = GetComponent<Animator>();
    }



    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _layer))
            {
                _destination = hit.point;
               
                isMove = true;
            }
        }

        if (isMove)
        {
            anim.SetBool(hashIsRun, true);
            Move();
        }
        else
        {
            anim.SetBool(hashIsRun, false);
        }
    }

    void Move()
    {
        if (Vector3.Distance(transform.position, _destination) == 0.0F)
        {
            isMove = false;
            return;
        }

        Vector3 direction = _destination - transform.position;
        direction = Vector3.Normalize(direction);
        // direction = new Vector3(direction.x, 0, direction.z);
        if(!slip.isGoing)
        rb.MovePosition(tr.position + direction * Time.deltaTime * _velocity);

     //   _controller.Move(direction * Time.deltaTime * _velocity);
        
    }
}
