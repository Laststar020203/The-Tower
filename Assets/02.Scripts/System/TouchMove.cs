using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour {
	
	Transform tr;
	Vector3 movePos;
	bool isMove;
	public float distance = 100f;
	bool isTouch;
	Quaternion first; Animator anim;
    public float speed = 1;
    public bool isStop;

    // Use this for initialization
    void Start () {
		tr = GetComponent<Transform> ();

        anim = GetComponent<Animator>();
    }

    float t = 0;

    // Update is called once per frame
    void Update () {
        Debug.Log(Vector3.Distance(tr.position, movePos));


        //Vector2 pos = Input.GetTouch (0).position;
        //Vector3 theTouch = new Vector3 (pos.x, pos.y, 0.0f);
       
        if (Vector3.Distance (tr.position, movePos) >= distance && isTouch ) {
            if (isStop)
            {
                movePos = tr.position;
                return;
            }
			tr.Translate (Vector3.forward * Time.deltaTime * speed );
            anim.SetBool("IsMoving", true);

        }else
            anim.SetBool("IsMoving", false);


        if (Input.GetMouseButtonDown (0)) {
			isTouch = true;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {

				if (!isMove)
					 StartCoroutine (Turn(hit.point));
                
			}

		}
        Debug.Log(Vector3.Distance(tr.position, movePos));
       
    }
    IEnumerator Turn(Vector3 pos)
    {
       
        first = tr.rotation;
        movePos = pos;
        isMove = true;
        pos.y = 0;
        while (t <= 1)
        {
            tr.rotation = Quaternion.Slerp(first, Quaternion.LookRotation(pos), t);
            t += Time.deltaTime * 15f;
            yield return null;
        }
        t = 0;
        isMove = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ob")) isStop = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ob")) isStop = false;
    }
}

