using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot_2F : MonoBehaviour {

    public AnimationClip clips;
    public Animation anim;

    private void Start()
    {
       

        anim.clip = clips;
    }

    private void OnCollisionEnter(Collision coll)
    {

        if (coll.collider.CompareTag("PLAYER"))
        {
            anim.Play();
            
        }
    }
    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.CompareTag("PLAYER"))
        {
            anim.Stop();

        }
    }
}
