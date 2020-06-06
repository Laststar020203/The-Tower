using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load2 : MonoBehaviour {
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            GameObject.FindWithTag("SCENEMANAGER").GetComponent<SceneTurnManager>().SendMessage("AddScene", 3);
        }
    }
}
