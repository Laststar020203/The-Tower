using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCtrl : MonoBehaviour {


    MeshRenderer ms;
    public float seeWallCoolTime = 0.2f;
    public float hidenWallCoolTime = 3.0f;
    bool isStop = false;


	// Use this for initialization
	void Start () {

        ms = GetComponent<MeshRenderer>();
        StartCoroutine(FlashWall());
	}
	
	
	IEnumerator FlashWall()
    {
        while (!isStop)
        {
            for (float i = 0f; i < 1; i += 0.1f)
            {

                ms.material.SetColor("_EmissionColor", new Color(i, i, i));
                Debug.Log(i);
                yield return new WaitForSeconds(0.01f);

            }
            yield return new WaitForSeconds(1);


            for (float i = 1f; i > -1; i -= 0.1f)
            {

                ms.material.SetColor("_EmissionColor", new Color(i, i, i));
                Debug.Log(i);

                yield return new WaitForSeconds(0.01f);

            }
            yield return new WaitForSeconds(5);

        }
        

        
    
    }

    
}
