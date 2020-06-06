using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lightning : MonoBehaviour
{
    protected GameObject Dome;
    protected void Deaths()
    {
        StartCoroutine(Destroys());
    }

    protected void CreateDome(){
        Instantiate(Dome, new Vector3(gameObject.transform.position.x
                                      , 0, gameObject.transform.position.z),
                    Quaternion.identity);
    }

    private IEnumerator Destroys(){
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    } 
}
