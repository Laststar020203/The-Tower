using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTurnManager : MonoBehaviour {


    private GameObject fade;

    private Animator anim;
   
    private readonly int hashFade = Animator.StringToHash("FadeOut");
    

    int sceneCount = 0;

  



    public void AddScene(int sceneNum)
    {

        fade = GameObject.FindGameObjectWithTag("FADE");
        anim = fade.GetComponent<Animator>();

      

        StartCoroutine(SceneFade(sceneNum));

        







    }



    IEnumerator SceneFade(int count)
    {
        sceneCount = count;
        anim.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1f);


        SceneManager.LoadScene(count);
        
    }
    

   

   
}


