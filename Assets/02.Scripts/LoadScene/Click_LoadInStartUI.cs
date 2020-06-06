using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Click_LoadInStartUI : MonoBehaviour {

    public Animator fade;
    public Image fadeImage;

    bool fadein = false;

  

    public void OnLoadScene()
    {


        StartCoroutine(FadeIn());        
    }

    IEnumerator FadeIn()
    {
        fade.SetBool("Fade" , true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
        SceneManager.LoadScene(1);

    }
}
