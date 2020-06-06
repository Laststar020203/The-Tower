using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMoveCtrl : MonoBehaviour {

    Transform tr;
    Vector3 movePos;
    bool isMove;
    public float distance = 100f;
    bool isTouch;
    Quaternion first;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    float t = 0;

    // Update is called once per frame
    private void Update()
    {


        //Vector2 pos = Input.GetTouch (0).position;
        //Vector3 theTouch = new Vector3 (pos.x, pos.y, 0.0f);
        if (Vector3.Distance(tr.position, movePos) > distance && isTouch)
        {
            Debug.Log(Vector3.Distance(tr.position, movePos));
            tr.Translate(Vector3.forward * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                if (!isMove)
                    StartCoroutine(Turn(hit.point));
            }

        }
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
            t += Time.deltaTime * 5f;
            yield return null;
        }
        t = 0;
        isMove = false;
    }
}
