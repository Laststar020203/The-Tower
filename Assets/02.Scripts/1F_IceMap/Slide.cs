using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    private Transform playerTr;
    private Vector3 targetPos;
    private void Start()
    {
        playerTr = gameObject.GetComponent<Transform>();
        targetPos = playerTr.position;

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = GetClickedObjectPos();
        }
    }

    private Vector3 GetClickedObjectPos()
    {
        GameObject _target = null;
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            _target = hit.collider.gameObject;
        }
        return _target.transform.position;
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawSphere(targetPos, 0.4f);
    }
}
