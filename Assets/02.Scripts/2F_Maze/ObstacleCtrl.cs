using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour {

	public enum Obstacle { Thorn , Weights , Cliff};
    public Obstacle ob;
    Transform tr;

    public float CoolTime = 2f;
    private float nextTime = 0f;
   public float checkdistance = 3f;

    public GameObject wave;
    GameObject waveClone;
    public Transform playerTr;

    Rigidbody rb;
    Vector3 originPos;

    MeshRenderer ms;
    BoxCollider coll;

    
  

    // Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();

        coll = GetComponent<BoxCollider>();
        ms = GetComponent<MeshRenderer>();

        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        
       
      

        originPos = tr.position + new Vector3(0,50,0);


       
    }
	
	// Update is called once per frame
	void Update () {
        
       float distance = Vector3.Distance(tr.position, playerTr.position);



        if (distance <= checkdistance)
        {

            Action();
            
        }
        
           
           


        // Action();



    }
    void Action()
    {
        
      switch (ob)
        {
            case Obstacle.Thorn:
                break;
            case Obstacle.Weights:
                tr.rotation = Quaternion.Euler(0, 0, 0);
                rb.useGravity = true;
                if (Time.time >= nextTime)
                {
                    waveClone = Instantiate(wave, new Vector3(tr.position.x, 1, tr.position.z), Quaternion.Euler(90, 0, 0));
                    Destroy(waveClone, 2.0f);
                    rb.useGravity = false;
                    tr.position = originPos;
                   
                    nextTime = Time.time + CoolTime;
                }
               
                break;
            case Obstacle.Cliff:

                if (Time.time >= nextTime)
                {
                    waveClone = Instantiate(wave, new Vector3(tr.position.x, 1, tr.position.z), Quaternion.Euler(90, 0, 0));
                    Destroy(waveClone, 2.0f);
              
                    nextTime = Time.time + CoolTime;
                }
                if ((int)Time.time % 10 >= 5)
                {
                    
                    
                    coll.enabled = false;
                    ms.enabled = false;
                }
                else
                {
                    coll.enabled = true;
                    ms.enabled = true;
                   
                }
               
                break;
            default:
                break;
        }
    }
    

    


}
