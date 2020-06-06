using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeNextScene : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            GameObject.FindWithTag("SCENEMANAGER").GetComponent<SceneTurnManager>().SendMessage("AddScene",2);
        }
    }
}

