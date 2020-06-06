using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Home : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PLAYER"))
        {
            GameSystem.system.TurnScene();
        }
    }

}
