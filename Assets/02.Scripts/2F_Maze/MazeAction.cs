using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAction : MonoBehaviour {

    Transform tr;
    Vector3 spawnPos;

    private void Start()
    {
        tr = GetComponent<Transform>();
        spawnPos = Manager_Maze.instance.spawnPos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        switch ((int)coll.collider.gameObject.GetComponent<ObstacleCtrl>().ob)
        {

            case 0:
                //가시

                tr.position = spawnPos;
              
                
                break;
            case 1:
                //100t추
                tr.position = spawnPos;

                break;
            case 2:
                //낭떠러지

                tr.position = spawnPos;

                break;
            default:
                break;
        }
    }
}
