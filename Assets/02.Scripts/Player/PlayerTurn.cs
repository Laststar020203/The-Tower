using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour {

    RaycastHit Hit;
    float TurnSpeed;
    Quaternion dr;

    Vector3 Click;

    void Start()
    {

        TurnSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out Hit);
            Click = Hit.point;

            dr = Quaternion.LookRotation((Click - transform.position).normalized);

            dr.x = 0;
            dr.z = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, dr, TurnSpeed * Time.deltaTime);
        }
    }

}
