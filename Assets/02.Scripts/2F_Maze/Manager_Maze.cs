using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Maze : MonoBehaviour {

    public static Manager_Maze instance;
    public Vector3 spawnPos;
   
   
  
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("PLAYER"))
        {
            SceneManager.LoadScene("2F_Boss");
        }
    }

}
